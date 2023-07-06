namespace AirsoftWebStore.Web.ViewModels.Equipment
{
    public class EquipmentDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
