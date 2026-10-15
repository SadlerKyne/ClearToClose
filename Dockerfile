FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ClearToClose/*.csproj ./ClearToClose/
RUN dotnet restore ./ClearToClose/ClearToClose.csproj
COPY ClearToClose/ ./ClearToClose/
RUN dotnet publish ./ClearToClose/ClearToClose.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "ClearToClose.dll"]
