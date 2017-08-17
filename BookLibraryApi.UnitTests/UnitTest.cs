using BookLibraryApi.Controllers.EntityControllers;
using BookLibraryApi.Controllers.EntityLinkControllers;
using BookLibraryApi.Controllers.SpecificControllers;
using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.Entities;
using BookLibraryApi.Models.EntityLinks;
using BookLibraryApi.Repositories.EntityLinkRepositories;
using BookLibraryApi.Repositories.EntityRepositories;
using BookLibraryApi.Repositories.SpecificRepositories;
using DatabaseHelpers.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryApi.UnitTests
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

        private static void FillDatabaseWithAdditionalChecks(BookLibraryContext context)
        {
            // Entity Controllers

            var authorsController = new AuthorsController(new AuthorsRepository(context), null);
            var editionsController = new EditionsController(new EditionsRepository(context), null);
            var genresController = new GenresController(new GenresRepository(context), null);
            var volumesController = new VolumesController(new VolumesRepository(context), null);
            var volumeExemplarsController = new VolumeExemplarsController(new VolumeExemplarsRepository(context), null);
            var worksController = new WorksController(new WorksRepository(context), null);
            var workKindsController = new WorkKindsController(new WorkKindsRepository(context), null);

            // Entity Link Controllers

            var editionVolumeLinksController = new EditionVolumeLinksController(new EditionVolumeLinksRepository(context), null);
            var volumeWorkLinksController = new VolumeWorkLinksController(new VolumeWorkLinksRepository(context), null);
            var workAuthorLinksController = new WorkAuthorLinksController(new WorkAuthorLinksRepository(context), null);

            // Filling and checking

            IActionResult result;
            Author authorJackLondon;
            Author authorTheodoreDreiser;
            Genre genreBellesletres;
            Genre genreRealism;
            Work workMartenEden;
            Work workWhiteFang;
            Work workFinancier;
            Work workSisterCarrie;

            result = authorsController.Get(0);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

            result = authorsController.Put(new Author { Id = 0, Name = "Jack London" });
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

            result = authorsController.Post(null);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsTrue(((BadRequestObjectResult)result).Value.Equals("Entity is null."));

            result = authorsController.Post(new Author { Name = "Jack London" });
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
            Assert.IsInstanceOfType(((CreatedAtActionResult)result).Value, typeof(Author));
            authorJackLondon = (Author)((CreatedAtActionResult)result).Value;
            Assert.IsTrue(authorJackLondon.Id != 0);

            result = authorsController.Post(new Author { Name = "Theodore Dreiser" });
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
            Assert.IsInstanceOfType(((CreatedAtActionResult)result).Value, typeof(Author));
            authorTheodoreDreiser = (Author)((CreatedAtActionResult)result).Value;

            Assert.IsTrue(authorTheodoreDreiser.Id != authorJackLondon.Id);

            result = authorsController.GetCount();
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(int));
            Assert.IsTrue((int)((OkObjectResult)result).Value == 2);

            authorTheodoreDreiser.Name = "Theodore Herman Albert Dreiser";
            result = authorsController.Put(authorTheodoreDreiser);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(Author));
            authorTheodoreDreiser = (Author)((OkObjectResult)result).Value;
            Assert.IsTrue(authorTheodoreDreiser.Name == "Theodore Herman Albert Dreiser");

            genreBellesletres = (Genre)((CreatedAtActionResult)genresController.Post(new Genre { Name = "Belles-letres" })).Value;
            genreRealism = (Genre)((CreatedAtActionResult)genresController.Post(new Genre { Name = "Realism" })).Value;

            workMartenEden = (Work)((CreatedAtActionResult)worksController.Post(new Work { Name = "Marten Eden", GenreId = genreBellesletres.Id })).Value;
            workWhiteFang = (Work)((CreatedAtActionResult)worksController.Post(new Work { Name = "White Fang", GenreId = genreBellesletres.Id })).Value;

            workFinancier = (Work)((CreatedAtActionResult)worksController.Post(new Work { Name = "Financier", GenreId = genreRealism.Id, AltGenreId = genreBellesletres.Id })).Value;
            workSisterCarrie = (Work)((CreatedAtActionResult)worksController.Post(new Work { Name = "Sister Carrie", GenreId = genreRealism.Id, AltGenreId = genreBellesletres.Id })).Value;

            result = workAuthorLinksController.Post(new WorkAuthorLink { WorkId = workMartenEden.Id, AuthorId = authorJackLondon.Id });
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
            result = workAuthorLinksController.Post(new WorkAuthorLink { WorkId = workWhiteFang.Id, AuthorId = authorJackLondon.Id });
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));

            result = workAuthorLinksController.Post(new WorkAuthorLink { WorkId = workFinancier.Id, AuthorId = authorTheodoreDreiser.Id });
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
            result = workAuthorLinksController.Post(new WorkAuthorLink { WorkId = workSisterCarrie.Id, AuthorId = authorTheodoreDreiser.Id });
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
        }

        private static void DoSomeSearchingsInFilledDatabase(BookLibraryContext context)
        {
            // Specific Controllers

            var searchController = new SearchController(new SearchRepository(context), null);

            // Searching

            IActionResult result;

            result = searchController.GetAuthorsByNamePattern("Ja Lon");
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(IReadOnlyList<Author>));

            var authorJackLondon = ((IReadOnlyList<Author>)((OkObjectResult)result).Value).FirstOrDefault();
            Assert.IsNotNull(authorJackLondon);

            result = searchController.GetAuthorsByNamePattern("Theo Drei");
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(IReadOnlyList<Author>));

            var authorTheodoreDreiser = ((IReadOnlyList<Author>)((OkObjectResult)result).Value).FirstOrDefault();
            Assert.IsNotNull(authorTheodoreDreiser);

            result = searchController.GetWorksByNamePattern("Mar Ed");
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(IReadOnlyList<Work>));

            var workMartenEden = ((IReadOnlyList<Work>)((OkObjectResult)result).Value).FirstOrDefault();
            Assert.IsNotNull(workMartenEden);

            result = searchController.GetWorksByAuthor(authorTheodoreDreiser.Id);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(IReadOnlyList<Work>));
            Assert.IsTrue(((IReadOnlyList<Work>)((OkObjectResult)result).Value).Count == 2);

            Assert.IsNotNull(workMartenEden.GenreId);
            int someGenreId = workMartenEden.GenreId.Value;

            result = searchController.GetWorksByGenre(someGenreId);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(IReadOnlyList<Work>));
            Assert.IsTrue(((IReadOnlyList<Work>)((OkObjectResult)result).Value).Count == 4);

            result = searchController.GetWorksByAuthorAndGenre(authorJackLondon.Id, someGenreId);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(IReadOnlyList<Work>));
            Assert.IsTrue(((IReadOnlyList<Work>)((OkObjectResult)result).Value).Count == 2);
        }

        [TestMethod]
        public void TestCreateEmptyDatabase()
        {
            var context = CreateContext();
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }

        [TestMethod]
        public void TestCreateSampleDatabaseWithAdditionalChecks()
        {
            var context = CreateContext();
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            FillDatabaseWithAdditionalChecks(context);
       }

        [TestMethod]
        public void TestCreateSampleDatabaseWithAdditionalChecksAndSearches()
        {
            var context = CreateContext();
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            FillDatabaseWithAdditionalChecks(context);
            DoSomeSearchingsInFilledDatabase(context);
        }
    }
}
