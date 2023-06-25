namespace AirsoftWebStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using AirsoftWebStore.Data.Models;

    public class PartEntityConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder
                .HasOne(p => p.Gun)
                .WithMany(g => g.Parts)
                .HasForeignKey(p => p.GunId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
