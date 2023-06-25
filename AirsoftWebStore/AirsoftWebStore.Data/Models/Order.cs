namespace AirsoftWebStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
            this.Guns = new HashSet<Gun>();
            this.Parts = new HashSet<Part>();
            this.Equipments = new HashSet<Equipment>();
            this.Consumatives = new HashSet<Consumative>();
        }

        [Key]
        public Guid Id { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public ICollection<Gun> Guns { get; set; } = null!;

        public ICollection<Part> Parts { get; set; } = null!;

        public ICollection<Equipment> Equipments { get; set; } = null!;

        public ICollection<Consumative> Consumatives { get; set; } = null!;
    }
}
