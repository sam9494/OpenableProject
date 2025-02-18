using System.Data.Common;

namespace OpenTableProject.Interface;

public interface IDBConnectionFactory
{
    DbConnection CreateDBConnection();
}