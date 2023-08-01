namespace AirsoftWebStore.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data.Configuration;
    using AirsoftWebStore.Data.Models;

    public class AirsoftStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AirsoftStoreDbContext(DbContextOptions<AirsoftStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Gunsmith> Gunsmiths { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Gun> Guns { get; set; } = null!;

        public DbSet<Part> Parts { get; set; } = null!;

        public DbSet<Equipment> Equipments { get; set; } = null!;

        public DbSet<Consumative> Consumatives { get; set; } = null!;

        public DbSet<Cart> Carts { get; set; } = null!;

        public DbSet<CartItem> CartItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfigurationsFromAssembly(typeof(CategoryEntityTypeConfiguration).Assembly);

            base.OnModelCreating(builder);
        }
    }
}