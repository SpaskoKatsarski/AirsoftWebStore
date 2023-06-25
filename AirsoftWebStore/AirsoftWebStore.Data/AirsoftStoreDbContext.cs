﻿namespace AirsoftWebStore.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data.Configuration;
    using AirsoftWebStore.Data.Models;

    public class AirsoftStoreDbContext : IdentityDbContext
    {
        public AirsoftStoreDbContext(DbContextOptions<AirsoftStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Consumative> Consumatives { get; set; } = null!;

        public DbSet<Equipment> Equipments { get; set; } = null!;

        public DbSet<Gun> Guns { get; set; } = null!;

        public DbSet<Part> Parts { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new CategoryEntityTypeConfiguration()
                .Configure(builder.Entity<Category>());

            builder
                .ApplyConfigurationsFromAssembly(typeof(CategoryEntityTypeConfiguration).Assembly);

            base.OnModelCreating(builder);
        }
    }
}