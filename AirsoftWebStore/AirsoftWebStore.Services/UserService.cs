namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;

    public class UserService : IUserService
    {
        private readonly AirsoftStoreDbContext context;

        public UserService(AirsoftStoreDbContext context)
        {
            this.context = context;
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
