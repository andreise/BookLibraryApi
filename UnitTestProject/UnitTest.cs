using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseHelpers.Common;
using BookLibraryApi.Models.Entities;
using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Repositories.EntityRepositories;
using BookLibraryApi.Repositories.EntityLinkRepositories;
using BookLibraryApi.Repositories.SpecificRepositories;
using BookLibraryApi.Controllers.EntityControllers;
using BookLibraryApi.Controllers.EntityLinkControllers;
using BookLibraryApi.Controllers.SpecificControllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        private static BookLibraryContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookLibraryContext>();

            optionsBuilder.UseSqlServer(
                DatabaseHelper.GetConnectionString(DatabaseHelper.GetDatabaseTestName()),
                builder => builder.MigrationsAssembly("BookLibraryApi"));

            return new BookLibraryContext(optionsBuilder.Options);
        }

        private static void FillDatabase(BookLibraryContext context)
        {
            // Entities

            var authorsController = new AuthorsController(new AuthorsRepository(context), null);
            var editionsController = new EditionsController(new EditionsRepository(context), null);
            var genresController = new GenresController(new GenresRepository(context), null);
            var volumesController = new VolumesController(new VolumesRepository(context), null);
            var volumeExemplarsController = new VolumeExemplarsController(new VolumeExemplarsRepository(context), null);
            var worksController = new WorksController(new WorksRepository(context), null);
            var workKindsController = new WorkKindsController(new WorkKindsRepository(context), null);

            // Entity Links

            var editionVolumeLinksController = new EditionVolumeLinksController(new EditionVolumeLinksRepository(context), null);
            var volumeWorkLinksController = new VolumeWorkLinksController(new VolumeWorkLinksRepository(context), null);
            var workAuthorLinksController = new WorkAuthorLinksController(new WorkAuthorLinksRepository(context), null);


            IActionResult// result =
            //    authorsController.Put(0, new Author { Id = 0, Name = "Jack London" });
            //Assert.IsInstanceOfType(result, typeof(NotFoundResult));

            result = authorsController.Post(new Author { Name = "Jack London" });
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var x = result as OkObjectResult;
            var y = (Author)x.Value;
            //Assert.IsTrue(y.Id != null);

            result = authorsController.Get((int)y.Id);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var createdAuthor = ((OkObjectResult)result).Value as Author;
            Assert.IsNotNull(createdAuthor);

            authorsController.Post(new Author { Name = "Theodore Dreiser" });

            genresController.Post(new Genre { Name = "Belles-letres" });
            genresController.Post(new Genre { Name = "Realism" });

            worksController.Post(new Work { Name = "Marten Eden" });
            worksController.Post(new Work { Name = "White Fang" });

            worksController.Post(new Work { Name = "Finacier" });
            worksController.Post(new Work { Name = "White Fang" });
        }

        [TestMethod]
        public void TestCreateEmptyDatabase()
        {
            var context = CreateContext();
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }

        [TestMethod]
        public void TestCreateSampleDatabase()
        {
            var context = CreateContext();
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            FillDatabase(context);
       }
    }
}
