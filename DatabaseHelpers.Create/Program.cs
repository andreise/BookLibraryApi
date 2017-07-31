using DatabaseHelpers.Common;

namespace DatabaseHelpers.Create
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper.CreateDatabase(DatabaseHelper.GetDatabaseName());
        }
    }
}