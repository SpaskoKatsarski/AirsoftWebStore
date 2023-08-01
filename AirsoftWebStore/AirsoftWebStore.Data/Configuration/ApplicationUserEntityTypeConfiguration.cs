namespace AirsoftWebStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using AirsoftWebStore.Data.Models;

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
        }
    }
}
