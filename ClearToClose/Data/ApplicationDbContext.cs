using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClearToClose.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<FinancialProfile> FinancialProfiles => Set<FinancialProfile>();
    public DbSet<Debt> Debts => Set<Debt>();
    public DbSet<Bill> Bills => Set<Bill>();
    public DbSet<Paycheck> Paychecks => Set<Paycheck>();
    public DbSet<Purchase> Purchases => Set<Purchase>();
}
