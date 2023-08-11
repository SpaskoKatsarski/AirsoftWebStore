namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Gun;
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Web.ViewModels.Home;
    using AirsoftWebStore.Services.Models.Gun;
    using AirsoftWebStore.Web.ViewModels.Gun.Enums;
    using static AirsoftWebStore.Common.ErrorMessages.Gun;

    public class GunService : IGunService
    {
        private readonly AirsoftStoreDbContext context;

        public GunService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<IndexViewModel>> GetTopThreeWithMostCountsAsync()
        {
            int taken = 3;

            int totalGuns = this.context.Guns.Count();

            bool hasEnough = totalGuns >= 3;

            if (!hasEnough)
            {
                taken = totalGuns;
            }

            IEnumerable<IndexViewModel> model = await this.context.Guns
                .AsNoTracking()
                .Where(g => g.IsActive)
                .OrderByDescending(g => g.Quantity)
                .Take(taken)
                .Select(g => new IndexViewModel() 
                {
                    Id = g.Id.ToString(),
                    Name = g.Name,
                    ImageUrl = g.ImageUrl
                })
                .ToListAsync();

            return model;
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

        public async Task<AllGunsFilteredAndPagedServiceModel> AllAsync(AllGunsQueryModel queryModel)
        {
            IQueryable<Gun> gunsQuery = this.context.Guns
                .Where(g => g.IsActive)
                .AsQueryable();

            if (!string.IsNullOrEmpty(queryModel.Category))
            {
                gunsQuery = gunsQuery
                    .Where(g => g.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%"
;
                gunsQuery = gunsQuery
                    .Where(g => EF.Functions.Like(g.Name, wildCard) ||
                                EF.Functions.Like(g.Manufacturer, wildCard));
            }

            gunsQuery = queryModel.GunSorting switch
            {
                GunSorting.Newest => gunsQuery.OrderByDescending(g => g.Year),
                GunSorting.Oldest => gunsQuery.OrderBy(g => g.Year),
                GunSorting.PriceDescending => gunsQuery.OrderByDescending(p => p.Price),
                GunSorting.PriceAscending => gunsQuery.OrderBy(g => g.Price),
                _ => gunsQuery
            };

            IEnumerable<GunAllViewModel> guns = await gunsQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.GunsPerPage)
                .Take(queryModel.GunsPerPage)
                .Select(g => new GunAllViewModel()
                {
                    Id = g.Id.ToString(),
                    Name = g.Name,
                    Price = g.Price,
                    ImageUrl = g.ImageUrl
                })
                .ToListAsync();

            AllGunsFilteredAndPagedServiceModel serviceModel = new AllGunsFilteredAndPagedServiceModel()
            {
                TotalGunsCount = gunsQuery.Count(),
                Guns = guns
            };

            return serviceModel;
        }

        public async Task DeleteAsync(string id)
        {
            Gun gun = await this.context.Guns
                .Where(g => g.IsActive)
                .FirstAsync(g => g.Id.ToString() == id);

            gun.IsActive = false;

            await this.context.SaveChangesAsync();
        }

        public async Task<string> EditAsync(GunFormViewModel model)
        {
            Gun? gun = await this.context.Guns.FindAsync(Guid.Parse(model.Id!));

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
                .AsNoTracking()
                .Where(g => g.IsActive)
                .AnyAsync(g => g.Id.ToString() == id);

            return exists;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await this.context.Guns
                .AsNoTracking()
                .Where(g => g.IsActive)
                .AnyAsync(g => g.Name.ToLower() == name.ToLower());
        }

        public async Task<GunDetailViewModel> GetDetailsAsync(string id)
        {
            Gun? gun = await this.context.Guns
                .AsNoTracking()
                .Where(g => g.IsActive)
                .Include(g => g.Category)
                .FirstOrDefaultAsync(g => g.Id.ToString() == id);

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
                Category = gun.Category.Name
            };

            return gunModel;
        }

        public async Task<GunDeleteViewModel> GetGunForDeleteByIdAsync(string id)
        {
            Gun? gun = await this.context.Guns
                .AsNoTracking()
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
                .AsNoTracking()
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

        public async Task<Gun> GetGunByIdAsync(string id)
        {
            Gun gun = await this.context.Guns
                .Where(g => g.IsActive)
                .FirstAsync(g => g.Id.ToString() == id);

            return gun;
        }

        public async Task<string> GetCurrentNameAsync(string id)
        {
            string name = (await this.context.Guns
                .AsNoTracking()
                .Where(e => e.IsActive)
                .FirstAsync(e => e.Id.ToString() == id))
                .Name;

            return name;
        }
    }
}
