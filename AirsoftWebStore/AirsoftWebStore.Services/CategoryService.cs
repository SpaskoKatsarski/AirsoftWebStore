namespace AirsoftWebStore.Services
{
    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Category;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly AirsoftStoreDbContext context;

        public CategoryService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CategoryFormViewModel>> AllAsync()
        {
            IEnumerable<CategoryFormViewModel> categories = await this.context
                .Categories
                .AsNoTracking()
                .Select(c => new CategoryFormViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return categories;
        }

        public async Task<IEnumerable<string>> AllNamesAsync()
        {
            IEnumerable<string> categoryNames = await this.context.Categories
                .AsNoTracking()
                .Select(c => c.Name)
                .ToListAsync();

            return categoryNames;
        }

        public Task<bool> ExistsByIdAsync(int id)
        {
            return this.context.Categories
                .AnyAsync(c => c.Id == id);
        }
    }
}
