namespace AirsoftWebStore.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data.Configuration;
    using AirsoftWebStore.Data.Models;
    using static Common.GeneralApplicationConstants;

    public class AirsoftStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AirsoftStoreDbContext(DbContextOptions<AirsoftStoreDbContext> options)
            : base(options)
        {
            if (!this.Database.IsRelational())
            {
                this.Database.EnsureCreated();
            }
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

            this.SeedAdministrator(builder);

            base.OnModelCreating(builder);
        }

        private void SeedAdministrator(ModelBuilder builder)
        {
            //Seeding a  'Administrator' role to AspNetRoles table
            builder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid> { Id = Guid.Parse("2c5e174e-3b0e-446f-86af-483d56fd7210"), Name = AdminRoleName, NormalizedName = AdminRoleName.ToUpper() });

            //Seeding the relation between our user and role to AspNetUserRoles table
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                    UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                }
            );
        }
    }
}