namespace AirsoftWebStore.Web.ViewModels.Gun
{
    public class GunDetailViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }
    }
}
