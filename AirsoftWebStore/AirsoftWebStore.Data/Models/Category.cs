﻿namespace AirsoftWebStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static AirsoftWebStore.Common.EntityValidationConstants.Category;

    public class Category
    {
        public Category()
        {
            this.Guns = new HashSet<Gun>();
            this.Parts = new HashSet<Part>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Gun> Guns { get; set; }

        public ICollection<Part> Parts { get; set; }
    }
}
