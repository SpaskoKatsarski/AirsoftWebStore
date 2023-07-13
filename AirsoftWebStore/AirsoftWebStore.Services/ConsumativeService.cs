namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Consumative;

    public class ConsumativeService : IConsumativeService
    {
        private readonly AirsoftStoreDbContext context;

        public ConsumativeService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        // Add configuration for Consumatives beacuse IsActive will be false by default
        public async Task<IEnumerable<ConsumativeAllViewModel>> AllAsync()
        {
            IEnumerable<ConsumativeAllViewModel> consumatives = await this.context.Consumatives
                .AsNoTracking()
                .Where(c => c.IsActive)
                .Select(c => new ConsumativeAllViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                    Price = c.Price
                })
                .ToListAsync();

            return consumatives;

        }

        public async Task<string> AddAsync(ConsumativeFormViewModel model)
        {
            Consumative consumative = new Consumative()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Quantity = model.Quantity
            };

            await this.context.AddAsync(consumative);
            await this.context.SaveChangesAsync();

            return consumative.Id.ToString();
        }

        public async Task EditAsync(ConsumativeFormViewModel model)
        {
            Consumative consumative = await this.context.Consumatives
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id.ToString() == model.Id);

            consumative.Name = model.Name;
            consumative.Description = model.Description;
            consumative.ImageUrl = model.ImageUrl;
            consumative.Price = model.Price;
            consumative.Quantity = model.Quantity;

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            Consumative equipment = await this.context.Consumatives
                .Where(e => e.IsActive)
                .FirstAsync(e => e.Id.ToString() == id);

            equipment.IsActive = false;

            await this.context.SaveChangesAsync();
        }

        public async Task<ConsumativeDetailsViewModel> GetForDetailsAsync(string id)
        {
            Consumative consumative = await this.context.Consumatives
                .AsNoTracking()
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id.ToString() == id);

            ConsumativeDetailsViewModel model = new ConsumativeDetailsViewModel()
            {
                Id = consumative.Id.ToString(),
                Name = consumative.Name,
                Description = consumative.Description,
                ImageUrl = consumative.ImageUrl,
                Price = consumative.Price,
                Quantity = consumative.Quantity
            };

            return model;
        }

        public async Task<ConsumativeFormViewModel> GetForEditAsync(string id)
        {
            Consumative consumative = await this.context.Consumatives
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id.ToString() == id);

            ConsumativeFormViewModel model = new ConsumativeFormViewModel()
            {
                Id = consumative.Id.ToString(),
                Name = consumative.Name,
                Description = consumative.Description,
                ImageUrl = consumative.ImageUrl,
                Price = consumative.Price,
                Quantity = consumative.Quantity
            };

            return model;
        }

        public async Task<ConsumativeDeleteViewModel> GetForDeleteAsync(string id)
        {
            Consumative consumative = await this.context.Consumatives
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id.ToString() == id);

            ConsumativeDeleteViewModel model = new ConsumativeDeleteViewModel()
            {
                Name = consumative.Name,
                ImageUrl = consumative.ImageUrl
            };

            return model;
        }

        public async Task<bool> ExistsByIdAsync(string id)
        {
            bool result = await this.context.Consumatives
                .AsNoTracking()
                .Where(e => e.IsActive)
                .AnyAsync(e => e.Id.ToString() == id);

            return result;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            bool result = await this.context.Consumatives
                .AsNoTracking()
                .Where(c => c.IsActive)
                .AnyAsync(c => c.Name == name);

            return result;
        }

        public async Task<string> GetCurrentNameAsync(string id)
        {
            string name = (await this.context.Consumatives
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id.ToString() == id))
                .Name;

            return name;
        }

        public async Task<Consumative> GetConsumativeByIdAsync(string id)
        {
            Consumative consumative = await this.context.Consumatives
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id.ToString() == id);

            return consumative;
        }
    }
}
