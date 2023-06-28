using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirsoftWebStore.Web.ViewModels.Part
{
    public class PartDetailViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }
    }
}
