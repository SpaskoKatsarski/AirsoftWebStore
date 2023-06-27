

namespace AirsoftWebStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using AirsoftWebStore.Data.Models;

    public class CartItemEntityTypeConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder
                .HasOne(i => i.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(i => i.CartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.Gun)
                .WithMany(g => g.CartItems)
                .HasForeignKey(i => i.GunId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.Part)
                .WithMany(p => p.CartItems)
                .HasForeignKey(i => i.PartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.Equipment)
                .WithMany(e => e.CartItems)
                .HasForeignKey(i => i.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.Consumative)
                .WithMany(c => c.CartItems)
                .HasForeignKey(i => i.ConsumativeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
