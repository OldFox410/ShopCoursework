using Microsoft.Data.SqlClient;
using Dapper;

namespace ElectricalShop.Migrator;

public class Migrator
{
    private readonly string _connectionString;
    private readonly string _migrationsFolderPath;

    public Migrator(string connectionString, string migrationsFolderPath)
    {
        _connectionString = connectionString;
        _migrationsFolderPath = migrationsFolderPath;
    }

    public void Migrate()
    {
        if (!Directory.Exists(_migrationsFolderPath))
            return;

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        EnsureMigrationTableExists(connection);

        var appliedMigrations = connection.Query<string>(
            "SELECT ScriptName FROM dbo.SchemaMigrations")
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var migrationFiles = Directory.GetFiles(_migrationsFolderPath, "*.sql")
            .Select(Path.GetFileName)
            .Except(appliedMigrations)
            .OrderBy(f => f)
            .ToList();

        foreach (var fileName in migrationFiles)
        {
            if (fileName is null)
                continue;

            var script = File.ReadAllText(Path.Combine(_migrationsFolderPath, fileName!));

            Console.WriteLine($"Применение: {fileName}");

            using var transaction = connection.BeginTransaction();
            try
            {
                connection.Execute(script, transaction: transaction);

                connection.Execute(
                    "INSERT INTO dbo.SchemaMigrations (ScriptName) VALUES (@ScriptName)",
                    new { ScriptName = fileName },
                    transaction
                    );

                transaction.Commit();
                Console.WriteLine($"Миграция {fileName} успешно применена.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Миграция {fileName} завершилась ошибкой: {ex.Message}.");
                throw;
            }
        }
        Console.WriteLine("Применение миграций завершено успешно.");
    }

    private void EnsureMigrationTableExists(SqlConnection connection)
    {
        var sql = @"
            IF OBJECT_ID(N'dbo.SchemaMigrations', N'U') IS NULL BEGIN
                CREATE TABLE dbo.SchemaMigrations (
                    MigrationId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
                    ScriptName NVARCHAR(255) NOT NULL UNIQUE,
                    AppliedAt DATETIME2 NOT NULL CONSTRAINT DF_SchemaMigrations_AppliedAt DEFAULT SYSDATETIME()
                );
            END";
        connection.Execute(sql);
    }
}