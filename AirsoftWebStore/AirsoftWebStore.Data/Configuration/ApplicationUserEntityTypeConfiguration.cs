namespace AirsoftWebStore.Data.Configuration
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.AspNetCore.Identity;

    using AirsoftWebStore.Data.Models;
    using static Common.GeneralApplicationConstants;

    public class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(u => u.FirstName)
                .HasDefaultValue("Test");

            builder
                .Property(u => u.LastName)
                .HasDefaultValue("Test");

            builder
                .Property(u => u.HasGunsmithRequest)
                .HasDefaultValue(false);

            builder.HasData(SeedUsers());
        }

        private ICollection<ApplicationUser> SeedUsers()
        {
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

            ApplicationUser user = new ApplicationUser()
            {
                Id = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"), // primary key
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail.ToUpper(),
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "admin123"),
                SecurityStamp = "1BC726483DA146C7AB96961EBD8FA88B",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Admin",
                LastName = "Adminov"
            };

            users.Add(user);

            return users;
        }
    }
}
