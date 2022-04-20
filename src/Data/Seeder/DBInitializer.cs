using Dapper;
using Data.Contracts;
using Data.Utils;

namespace Data.Seeder;

public class DBInitializer
{
    private readonly IConnectionService _connectionService;

    public DBInitializer(IConnectionService connectionService)
    {
        _connectionService = connectionService;
    }

    public async Task CreateSchemesAsync()
    {
        var dbConnection = _connectionService.GetPostgresConnection();

        var currentDirectory = Directory.GetCurrentDirectory();
        var a = System.AppContext.BaseDirectory;
        var b = System.Environment.CurrentDirectory;
        var folderPath = Path.Combine(currentDirectory, Queries.SchemeFolderPath);
        var schemeQueryFileNames = Directory.GetFiles(folderPath);

        using var transaction = dbConnection.BeginTransaction();
        foreach (var schemeQueryFileName in schemeQueryFileNames)
        {
            var schemeQuery = FileResourceUtility.LoadResource(folderPath, schemeQueryFileName);
            await dbConnection.ExecuteAsync(schemeQuery, transaction: transaction);
        }

        transaction.Commit();
    }
}
