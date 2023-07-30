namespace AirsoftWebStore.Services
{
    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;

    public class UserService : IUserService
    {
        private readonly AirsoftStoreDbContext context;

        public UserService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user = await dbContext
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
