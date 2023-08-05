namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.User;

    public class UserService : IUserService
    {
        private readonly AirsoftStoreDbContext context;

        public UserService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            IEnumerable<UserViewModel> users = await this.context.Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                    IsGunsmith = false
                })
                .ToListAsync();

            foreach (UserViewModel user in users)
            {
                bool isGunsmith = await this.context.Gunsmiths.AnyAsync(g => g.UserId.ToString() == user.Id)

                if (isGunsmith)
                {
                    user.IsGunsmith = true;
                }
            }

            return users;
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user = await this.context
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
