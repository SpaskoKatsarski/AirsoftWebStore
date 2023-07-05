namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Gun;
    using AirsoftWebStore.Data.Models;
    using static AirsoftWebStore.Common.ErrorMessages.Gun;

    public class GunService : IGunService
    {
        private readonly AirsoftStoreDbContext context;

        public GunService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<string> AddAsync(GunFormViewModel model)
        {
            Gun gun = new Gun()
            {
                Name = model.Name,
                Manufacturer = model.Manufacturer,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Year = model.Year,
                Price = model.Price,
                Quantity = model.Quantity,
                CategoryId = model.CategoryId
            };

            await this.context.Guns.AddAsync(gun);
            await this.context.SaveChangesAsync();

            return gun.Id.ToString();
        }

        public async Task<IEnumerable<GunAllViewModel>> AllAsync()
        {
            IEnumerable<GunAllViewModel> guns = await context.Guns
                .AsNoTracking()
                .Where(g => g.IsActive)
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

        public async Task DeleteAsync(string id)
        {
            Gun gun = await this.context.Guns
                .Where(g => g.IsActive)
                .FirstAsync(g => g.Id.ToString() == id);

            gun.IsActive = false;

            await this.context.SaveChangesAsync();
        }

        public async Task<string> EditAsync(string id, GunFormViewModel model)
        {
            Gun? gun = await this.context.Guns.FindAsync(Guid.Parse(id));

            if (gun == null)
            {
                throw new Exception(string.Format(GunNotFoundErrorMessage, id));
            }

            gun.Name = model.Name;
            gun.Manufacturer = model.Manufacturer;
            gun.Description = model.Description;
            gun.ImageUrl = model.ImageUrl;
            gun.Year = model.Year;
            gun.Price = model.Price;
            gun.Quantity = model.Quantity;
            gun.CategoryId = model.CategoryId;

            await this.context.SaveChangesAsync();

            return gun.Id.ToString();
        }

        public async Task<bool> ExistsByIdAsync(string id)
        {
            bool exists = await this.context.Guns
                .Where(g => g.IsActive)
                .AnyAsync(g => g.Id.ToString() == id);
            return exists;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await this.context.Guns
                .Where(g => g.IsActive)
                .AnyAsync(g => g.Name == name);
        }

        public async Task<GunDetailViewModel> GetDetailsAsync(string id)
        {
            Gun? gun = await this.context.Guns
                .Where(g => g.IsActive)
                .FirstAsync(g => g.Id.ToString() == id);

            if (gun == null)
            {
                throw new Exception(string.Format(GunNotFoundErrorMessage, id));
            }

            GunDetailViewModel gunModel = new GunDetailViewModel()
            {
                Id = gun.Id.ToString(),
                Name = gun.Name,
                Manufacturer = gun.Manufacturer,
                Description = gun.Description,
                ImageUrl = gun.ImageUrl,
                Year = gun.Year,
                Price = gun.Price,
                Quantity = gun.Quantity,
                CategoryId = gun.CategoryId
            };

            return gunModel;
        }

        public async Task<GunDeleteViewModel> GetGunForDeleteByIdAsync(string id)
        {
            Gun? gun = await this.context.Guns
                .Where(g => g.IsActive)
                .Include(g => g.Category)
                .FirstAsync(g => g.Id.ToString() == id);


            GunDeleteViewModel model = new GunDeleteViewModel()
            {
                Name = gun.Name,
                Category = gun.Category.Name,
                ImageUrl = gun.ImageUrl
            };

            return model;
        }

        public async Task<GunFormViewModel> GetGunForEditByIdAsync(string id)
        {
            Gun? gun = await this.context.Guns
                .Where(g => g.IsActive)
                .FirstAsync(g => g.Id.ToString() == id);

            GunFormViewModel formModel = new GunFormViewModel()
            {
                Id = gun.Id.ToString(),
                Name = gun!.Name,
                Manufacturer = gun.Manufacturer,
                Description = gun.Description,
                ImageUrl = gun.ImageUrl,
                Year = gun.Year,
                Price = gun.Price,
                Quantity = gun.Quantity,
                CategoryId = gun.CategoryId
            };

            return formModel;
        }
    }
}
