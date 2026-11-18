using Microsoft.Extensions.Configuration;

namespace ElectricalShop.Migrator;

internal class Program
{
    static void Main(string[] args)
    {
        string rawMigrationsPath = args.Length > 0 ? args[0] : throw new ArgumentException("Migration path is not provided.");
        string rawConfigPath = args.Length > 1 ? args[1] : throw new ArgumentException("Config path is not provided.");

        string workingDir = Directory.GetCurrentDirectory(); ;

        string migrationsPath = Path.IsPathRooted(rawMigrationsPath)
            ? rawMigrationsPath
            : Path.Combine(workingDir, rawMigrationsPath);

        string configDirectory = Path.IsPathRooted(rawConfigPath)
            ? rawConfigPath
            : Path.Combine(workingDir, rawConfigPath);

        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(configDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        string connectionString = config.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string not found.");

        var migrator = new Migrator(connectionString, migrationsPath);
        migrator.Migrate();
    }
}