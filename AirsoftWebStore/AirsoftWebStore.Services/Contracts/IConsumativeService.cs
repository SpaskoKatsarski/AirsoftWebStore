namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.Consumative;

    public interface IConsumativeService
    {
        Task<IEnumerable<ConsumativeAllViewModel>> AllAsync();

        Task<string> AddAsync(ConsumativeFormViewModel model);

        Task<ConsumativeDetailsViewModel> GetForDetailsAsync(string id);

        Task<bool> ExistsByIdAsync(string id);

        Task<bool> ExistsByNameAsync(string name);
    }
}
