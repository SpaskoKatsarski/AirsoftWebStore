namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryFormViewModel>> AllAsync();

        Task<IEnumerable<string>> AllNamesAsync();

        Task<bool> ExistsByIdAsync(int id);
    }
}
