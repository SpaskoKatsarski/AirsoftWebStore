namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Admin;

    public class AdminService : IAdminService
    {
        private AirsoftStoreDbContext context;

        public AdminService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AllRequestsViewModel>> GetAllReqeustsAsync()
        {
            IEnumerable<AllRequestsViewModel> models = await this.context.Users
                .AsNoTracking()
                .Where(u => u.HasGunsmithRequest)
                .Select(u => new AllRequestsViewModel()
                {
                    UserId = u.Id.ToString(),
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                })
                .ToListAsync();

            return models;  
        }
    }
}
