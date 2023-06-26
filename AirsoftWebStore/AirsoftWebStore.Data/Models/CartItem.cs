namespace AirsoftWebStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CartItem
    {
        public CartItem()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }

        public Cart Cart { get; set; } = null!;

        [ForeignKey(nameof(Gun))]
        public Guid? GunId { get; set; }

        public Gun? Gun { get; set; }

        [ForeignKey(nameof(Part))]
        public Guid? PartId { get; set; }

        public Part? Part { get; set; }

        [ForeignKey(nameof(Equipment))]
        public Guid? EquipmentId { get; set; }

        public Equipment? Equipment { get; set; }

        [ForeignKey(nameof(Consumative))]
        public Guid? ConsumativeId { get; set; }

        public Consumative? Consumative { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}