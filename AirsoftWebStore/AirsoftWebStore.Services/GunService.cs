namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Gun;

    public class GunService : IGunService
    {
        private readonly AirsoftStoreDbContext context;

        public GunService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<GunAllViewModel>> AllAsync()
        {
            IEnumerable<GunAllViewModel> guns = await context.Guns
                .AsNoTracking()
                .Select(g => new GunAllViewModel()
                {
                    Id = g.Id.ToString(),
                    Name = g.Name,
                    Price = g.Price,
                    ImageUrl = g.ImageUrl,
                })
                .ToListAsync();

            return guns;
        }
    }
}