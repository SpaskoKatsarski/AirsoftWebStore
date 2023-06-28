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

        public async Task<IEnumerable<PartAllViewModel>> AllAsync()
        {
            IEnumerable<PartAllViewModel> parts = await this.context.Parts
                .AsNoTracking()
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
                .FindAsync(Guid.Parse(id));

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
    }
}
