namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Part;
    using static AirsoftWebStore.Common.ErrorMessages.Part;

    public class PartService : IPartService
    {
        private readonly AirsoftStoreDbContext context;

        public PartService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<string> AddAsync(PartFormViewModel model)
        {
            Part part = new Part()
            {
                Name = model.Name,
                Manufacturer = model.Manufacturer,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Quantity = model.Quantity,
                CategoryId = model.CategoryId
            };

            await this.context.Parts.AddAsync(part);
            await this.context.SaveChangesAsync();

            return part.Id.ToString();
        }

        public async Task<IEnumerable<PartAllViewModel>> AllAsync()
        {
            IEnumerable<PartAllViewModel> parts = await this.context.Parts
                .AsNoTracking()
                .Where(p => p.IsActive)
                .Select(p => new PartAllViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                })
                .ToListAsync();

            return parts;
        }

        public async Task<PartDetailViewModel> GetDetailsAsync(string id)
        {
            Part? part = await this.context.Parts
                .AsNoTracking()
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == id);

            // TODO: Think of removing this from here
            if (part == null)
            {
                throw new Exception(string.Format(PartNotFoundErrorMessage, id));
            }

            PartDetailViewModel partModel = new PartDetailViewModel()
            {
                Id = part.Id.ToString(),
                Name = part.Name,
                Manufacturer = part.Manufacturer,
                Description = part.Description,
                ImageUrl = part.ImageUrl,
                Price=  part.Price,
                Quantity = part.Quantity,
                CategoryId = part.CategoryId
            };
            
            return partModel;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            bool result = await this.context.Parts
                .Where(p => p.IsActive)
                .AnyAsync(p => p.Name.ToLower() == name.ToLower());

            return result;
        }

        public async Task<bool> ExistsByIdAsync(string id)
        {
            bool result = await this.context.Parts
                .Where(p => p.IsActive)
                .AnyAsync(p => p.Id.ToString() == id);

            return result;
        }

        public async Task<PartFormViewModel> GetPartForEditAsync(string id)
        {
            Part part = await this.context.Parts
                .AsNoTracking()
                .Where(p => p.IsActive)
                .Include(p => p.Category)
                .FirstAsync(p => p.Id.ToString() == id);

            PartFormViewModel model = new PartFormViewModel()
            {
                Name = part.Name,
                Manufacturer = part.Manufacturer,
                Description = part.Description,
                ImageUrl = part.ImageUrl,
                Price = part.Price,
                Quantity = part.Quantity,
                CategoryId = part.CategoryId
            };

            return model;
        }

        public async Task EditAsync(string id, PartFormViewModel model)
        {
            Part part = await this.context.Parts
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == id);

            part.Name = model.Name;
            part.Manufacturer = model.Manufacturer;
            part.Description = model.Description;
            part.ImageUrl = model.ImageUrl;
            part.Price = model.Price;
            part.Quantity = model.Quantity;
            part.CategoryId = model.CategoryId;

            await this.context.SaveChangesAsync();
        }

        public async Task<PartDeleteViewModel> GetPartForDeleteAsync(string id)
        {
            Part part = await this.context.Parts
                .AsNoTracking()
                .Where(p => p.IsActive)
                .Include(p => p.Category)
                .FirstAsync(p => p.Id.ToString() == id);

            PartDeleteViewModel model = new PartDeleteViewModel()
            {
                Name = part.Name,
                Category = part.Category.Name,
                ImageUrl = part.ImageUrl
            };

            return model;
        }

        public async Task DeleteAsync(string id)
        {
            Part part = await this.context.Parts
                 .Where(p => p.IsActive)
                 .FirstAsync(p => p.Id.ToString() == id);

            part.IsActive = false;

            await this.context.SaveChangesAsync();
        }
    }
}
