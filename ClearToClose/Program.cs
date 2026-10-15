using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ClearToClose.Components;
using ClearToClose.Components.Account;
using ClearToClose.Data;

// Pin the culture to en-US so currency/number formatting (e.g. ToString("C"))
// is consistent regardless of the host OS's locale availability -- the minimal
// Linux container this runs in otherwise falls back to the invariant culture's
// generic "¤" currency symbol instead of "$".
var cultureInfo = new System.Globalization.CultureInfo("en-US");
System.Globalization.CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var builder = WebApplication.CreateBuilder(args);

// Render (and most host platforms) assign the port to listen on via PORT.
var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(port))
{
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
}

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

// Render injects DATABASE_URL (postgres://user:pass@host:port/db) when a Postgres
// database is attached. Fall back to the local SQLite connection string otherwise.
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
var usingPostgres = !string.IsNullOrEmpty(databaseUrl);

if (usingPostgres)
{
    var uri = new Uri(databaseUrl!);
    var userInfo = uri.UserInfo.Split(':');
    var npgsqlConnectionString = new Npgsql.NpgsqlConnectionStringBuilder
    {
        Host = uri.Host,
        Port = uri.Port > 0 ? uri.Port : 5432,
        Database = uri.AbsolutePath.TrimStart('/'),
        Username = userInfo[0],
        Password = userInfo.Length > 1 ? userInfo[1] : string.Empty,
        SslMode = Npgsql.SslMode.Require,
    }.ToString();

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(npgsqlConnectionString));
}
else
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(connectionString));
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

if (usingPostgres)
{
    // No separate Postgres migrations exist; the schema is created directly
    // from the current model on first boot against the attached database.
    using var scope = app.Services.CreateScope();
    scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Render terminates TLS at its own proxy and forwards plain HTTP, so trust its
// X-Forwarded-Proto header rather than redirect-looping on HTTPS enforcement.
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
