namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Equipment;
    using AirsoftWebStore.Data.Models;

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

        public async Task<string> AddAsync(EquipmentFormViewModel model)
        {
            Equipment equipment = new Equipment()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Quantity = model.Quantity
            };

            await this.context.Equipments.AddAsync(equipment);
            await this.context.SaveChangesAsync();

            return equipment.Id.ToString();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            bool result = await this.context.Equipments
                .Where(e => e.IsActive)
                .AnyAsync(e => e.Name.ToLower() == name.ToLower());

            return result;
        }

        public async Task<EquipmentDetailsViewModel> GetForDetailsAsync(string id)
        {
            Equipment equipment = await this.context.Equipments
                .AsNoTracking()
                .Where(e => e.IsActive)
                .FirstAsync(e => e.Id.ToString() == id);

            EquipmentDetailsViewModel model = new EquipmentDetailsViewModel()
            {
                Id = equipment.Id.ToString(),
                Name = equipment.Name,
                Description = equipment.Description,
                ImageUrl = equipment.ImageUrl,
                Price = equipment.Price,
                Quantity = equipment.Quantity
            };

            return model;
        }

        public async Task<bool> ExistsByIdAsync(string id)
        {
            bool result = await this.context.Equipments
                .AsNoTracking()
                .Where(e => e.IsActive)
                .AnyAsync(e => e.Id.ToString() == id);

            return result;
        }
    }
}
