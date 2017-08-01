using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseHelpers.Common;
using System.Data.SqlClient;
using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Controllers.EntityControllers;
using BookLibraryApi.Controllers.EntityLinkControllers;
using Microsoft.EntityFrameworkCore;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        private static void DeleteDatabase() => DatabaseHelper.DropDatabase(DatabaseHelper.GetDatabaseTestName());

        private static void DeleteDatabaseSilent()
        {
            try
            {
                DeleteDatabase();
            }
            catch (SqlException)
            {
            }
        }

        private static void CreateDatabase() => DatabaseHelper.CreateDatabase(DatabaseHelper.GetDatabaseTestName());

        private static BookLibraryContext CreateContext()
        {
            DbContextOptionsBuilder<BookLibraryContext> optionsBuilder = new DbContextOptionsBuilder<BookLibraryContext>();
            optionsBuilder.UseSqlServer(
                DatabaseHelper.GetConnectionString(DatabaseHelper.GetDatabaseTestName()),
                builder => builder.MigrationsAssembly("BookLibraryApi"));

            return new BookLibraryContext(optionsBuilder.Options);
        }

        [TestMethod]
        public void TestCreateDatabase()
        {
            DeleteDatabaseSilent();
            CreateDatabase();
        }

        [TestMethod]
        public void TestEnsureDeletedDatabase()
        {
            var context = CreateContext();
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void TestEnsureCreatedDatabase()
        {
            var context = CreateContext();
            context.Database.EnsureCreated();
        }

        [TestMethod]
        public void TestMigrateDatabase()
        {
            DeleteDatabaseSilent();

            var context = CreateContext();
            context.Database.Migrate();
        }
    }
}
