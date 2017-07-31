using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.EntityLinks;

namespace BookLibraryApi.Repositories.EntityLinkRepositories
{
    public sealed class WorkAuthorLinksRepository : EntityRepositoryBase<WorkAuthorLink>
    {
        public WorkAuthorLinksRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
