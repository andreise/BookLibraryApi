using System.Data.SqlClient;

namespace DatabaseHelpers.Common
{
    public static class DatabaseHelper
    {
        public static string GetDatabaseDevelopmentName() => "BookLibraryContext_Development";

        public static string GetDatabaseTestName() => "BookLibraryContext_Test";

        public static string GetConnectionString(string database = null) =>
            $"Server=(localdb)\\mssqllocaldb;Database={database};Trusted_Connection=True;MultipleActiveResultSets=true";

        public static object ExecuteScalar(string connectionString, string commandText)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(commandText, connection))
            {
                connection.Open();
                return command.ExecuteScalar();
            }
        }

        public static object CreateDatabase(string database) =>
            ExecuteScalar(GetConnectionString(), "CREATE DATABASE " + database);

        public static object DropDatabase(string database) =>
            ExecuteScalar(GetConnectionString(), "DROP DATABASE " + database);
    }
}
