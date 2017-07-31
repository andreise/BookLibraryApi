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
        private static void DeleteDatabase() => DatabaseHelper.DropDatabase(DatabaseHelper.GetDatabaseName());

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

        public static void CreateDatabase() => DatabaseHelper.CreateDatabase(DatabaseHelper.GetDatabaseName());

        [TestMethod]
        public void TestCreateDatabase()
        {
            DeleteDatabaseSilent();

            CreateDatabase();
        }

        private static void CreateDatabaseScheme()
        {
            // TODO: Perform migration
        }

        private static void RecreateDatabaseWithScheme()
        {
            DeleteDatabaseSilent();

            CreateDatabase();

            CreateDatabaseScheme();
        }

        [TestMethod]
        public void TestCreateAndFillDatabase()
        {
            // TODO: Uncomment 'RecreateDatabaseWithScheme'
            // when CreateDatabaseScheme will be implemented.
            
            // Until CreateDatabaseScheme is not implemented,
            // you can drop database by DatabaseHelpers.Drop app starting,
            // and then run Update-Database in Package Manager Console
            // to create and migrate database

            //RecreateDatabaseWithScheme();

        }
    }
}
