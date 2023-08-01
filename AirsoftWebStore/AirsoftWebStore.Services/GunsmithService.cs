namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Gunsmith;

    public class GunsmithService : IGunsmithService
    {
        private AirsoftStoreDbContext context;

        public GunsmithService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task BecomeGunsmithAsync(string userId, BecomeGunsmithFormModel model)
        {
            Gunsmith gunsmith = new Gunsmith()
            {
                UserId = Guid.Parse(userId),
                PhoneNumber = model.PhoneNumber
            };

            await this.context.Gunsmiths.AddAsync(gunsmith);
            await this.context.SaveChangesAsync();
        }

        public async Task<bool> IsGunsmithAsync(string userId)
        {
            bool result = await this.context.Gunsmiths
                .AnyAsync(g => g.UserId.ToString() == userId);

            return result;
        }
    }
}
