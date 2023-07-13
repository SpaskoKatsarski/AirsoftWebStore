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

        public async Task<string> EditAsync(EquipmentFormViewModel model)
        {
            Equipment equipment = await this.context.Equipments
                .Where(e => e.IsActive)
                .FirstAsync(e => e.Id.ToString() == model.Id);

            equipment.Name = model.Name;
            equipment.Description = model.Description;
            equipment.ImageUrl = model.ImageUrl;
            equipment.Price = model.Price;
            equipment.Quantity = model.Quantity;

            await this.context.SaveChangesAsync();

            return equipment.Id.ToString();
        }

        public async Task DeleteAsync(string id)
        {
            Equipment equipment = await this.context.Equipments
                .Where(e => e.IsActive)
                .FirstAsync(e => e.Id.ToString() == id);

            equipment.IsActive = false;

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            bool result = await this.context.Equipments
                .Where(e => e.IsActive)
                .AnyAsync(e => e.Name.ToLower() == name.ToLower());

            return result;
        }

        public async Task<bool> ExistsByIdAsync(string id)
        {
            bool result = await this.context.Equipments
                .AsNoTracking()
                .Where(e => e.IsActive)
                .AnyAsync(e => e.Id.ToString() == id);

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

        public async Task<EquipmentFormViewModel> GetForEditAsync(string id)
        {
            Equipment equipment = await this.context.Equipments
                .AsNoTracking()
                .Where(e => e.IsActive)
                .FirstAsync(e => e.Id.ToString() == id);

            EquipmentFormViewModel model = new EquipmentFormViewModel()
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

        public async Task<EquipmentDeleteViewModel> GetForDeleteAsync(string id)
        {
            Equipment equipment = await this.context.Equipments
                .AsNoTracking()
                .Where(e => e.IsActive)
                .FirstAsync(e => e.Id.ToString() == id);

            EquipmentDeleteViewModel model = new EquipmentDeleteViewModel()
            {
                Name = equipment.Name,
                ImageUrl = equipment.ImageUrl
            };

            return model;
        }

        public async Task<string> GetCurrentNameAsync(string id)
        {
            string name = (await this.context.Equipments
                .AsNoTracking()
                .Where(e => e.IsActive)
                .FirstAsync(e => e.Id.ToString() == id))
                .Name;

            return name;
        }

        public async Task<Equipment> GetEquipmentByIdAsync(string id)
        {
            Equipment equipment = await this.context.Equipments
                .Where(e => e.IsActive)
                .FirstAsync(e => e.Id.ToString() == id);

            return equipment;
        }
    }
}
