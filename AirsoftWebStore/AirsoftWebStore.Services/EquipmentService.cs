namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Equipment;

    public class EquipmentService : IEquipmentService
    {
        private readonly AirsoftStoreDbContext context;

        public EquipmentService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<EquipmentAllViewModel>> AllAsync()
        {
            IEnumerable<EquipmentAllViewModel> models = await this.context.Equipments
                .AsNoTracking()
                .Where(e => e.IsActive)
                .Select(e => new EquipmentAllViewModel()
                {
                    Id = e.Id.ToString(),
                    Name = e.Name,
                    ImageUrl = e.ImageUrl,
                    Price = e.Price
                })
                .ToListAsync();

            return models;
        }
    }
}
