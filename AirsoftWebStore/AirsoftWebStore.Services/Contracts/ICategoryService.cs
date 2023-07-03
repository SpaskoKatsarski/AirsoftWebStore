namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryFormViewModel>> AllAsync();

        Task<bool> ExistsByIdAsync(int id);
    }
}
