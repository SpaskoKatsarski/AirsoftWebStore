namespace AirsoftWebStore.Services
{
    using System.Collections.Generic;

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

        public async Task<IEnumerable<GunsmithViewModel>> AllAsync()
        {
            IEnumerable<GunsmithViewModel> gunsmiths = await this.context.Gunsmiths
                .Include(g => g.User)
                .Select(g => new GunsmithViewModel()
                {
                    Id = g.UserId.ToString(),
                    FullName = $"{g.User.FirstName} {g.User.LastName}",
                    Email = g.User.Email
                })
                .ToListAsync();

            return gunsmiths;
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

        public async Task RemoveGunsmithAsync(string userId)
        {
            bool exists = await this.context.Users
                .AnyAsync(u => u.Id.ToString() == userId);
            if (!exists)
            {
                throw new Exception("User with the provided ID does not exist!");
            }

            Gunsmith? gunsmith = await this.context.Gunsmiths
                .FirstOrDefaultAsync(g => g.UserId.ToString() == userId);

            if (gunsmith == null)
            {
                throw new Exception("Gunsmith with the provided ID does not exist!");
            }

            this.context.Gunsmiths.Remove(gunsmith);
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
