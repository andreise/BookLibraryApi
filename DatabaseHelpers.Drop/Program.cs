using DatabaseHelpers.Common;

namespace DatabaseHelpers.Drop
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper.DropDatabase(DatabaseHelper.GetDatabaseDevelopmentName());
        }
    }
}