using System.Data.Common;
using Microsoft.Data.SqlClient;
using OpenTableProject.Interface;

namespace OpenTableProject;

public class DBConnectionFactory:IDBConnectionFactory
{
    private readonly string _connectString;

    public DBConnectionFactory(string connectString)
    {
        _connectString = connectString;
    }

    public DbConnection CreateDBConnection()
    {
        var conn = new SqlConnection(_connectString);
        return conn;
    }
}