using System.Data;

namespace Data.Contracts;

public interface IConnectionService
{
    public IDbConnection GetPostgresConnection();

    public void CloseConnection();
}
