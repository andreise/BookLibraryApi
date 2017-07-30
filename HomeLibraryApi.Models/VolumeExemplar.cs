namespace HomeLibraryApi.Models
{
    public sealed class VolumeExemplar : IEntity
    {
        public int Id { get; set; }

        public int? VolumeId { get; set; }

        public Volume Volume { get; set; }

        public decimal? Price { get; set; }

        public int? YearOfPurchase { get; set; }

        public string InventoryNumber { get; set; }

        public bool? IsPresentOnSite { get; set; }
    }
}
