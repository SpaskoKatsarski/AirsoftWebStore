namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;

    public class GunsmithService : IGunsmithService
    {
        private AirsoftStoreDbContext context;

        public GunsmithService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task BecomeGunsmithAsync(string userId)
        {
            ApplicationUser? user = await this.context.Users
                .FindAsync(Guid.Parse(userId));

            if (user == null)
            {
                throw new Exception("User with the provided ID does not exist!");
            }

            Gunsmith gunsmith = new Gunsmith()
            {
                UserId = Guid.Parse(userId),
            };

            user.HasGunsmithRequest = false;

            await this.context.Gunsmiths.AddAsync(gunsmith);
            await this.context.SaveChangesAsync();
        }

        public async Task RemoveRequestAsync(string userId)
        {
            ApplicationUser? user = await this.context.Users
                .FindAsync(Guid.Parse(userId));

            if (user == null)
            {
                throw new Exception("User with the provided ID does not exist!");
            }

            user.HasGunsmithRequest = false;

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> IsGunsmithAsync(string userId)
        {
            bool result = await this.context.Gunsmiths
                .AnyAsync(g => g.UserId.ToString() == userId);

            return result;
        }

        public async Task AddUserRequestAsync(string userId)
        {
            ApplicationUser? user = await this.context.Users
                .FindAsync(Guid.Parse(userId));

            if (user == null)
            {
                throw new Exception("User with the provided ID does not exist!");
            }

            user.HasGunsmithRequest = true;

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> HasUserSentRequestAsync(string userId)
        {
            if (userId == null)
            {
                return false;
            }

            ApplicationUser? user = await this.context.Users
                .FindAsync(Guid.Parse(userId));

            if (user == null)
            {
                throw new Exception("User with the provided ID does not exist!");
            }

            return user.HasGunsmithRequest!;
        }
    }
}
