namespace HomeLibraryApi.Models
{
    public sealed class Genre : IEntityWithNameAndDescription
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
