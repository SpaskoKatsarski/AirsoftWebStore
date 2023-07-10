namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.Consumative;

    public interface IConsumativeService
    {
        Task<IEnumerable<ConsumativeAllViewModel>> AllAsync();

        Task<string> AddAsync(ConsumativeFormViewModel model);

        Task EditAsync(ConsumativeFormViewModel model);

        Task DeleteAsync(string id);

        Task<ConsumativeDetailsViewModel> GetForDetailsAsync(string id);

        Task<ConsumativeFormViewModel> GetForEditAsync(string id);

        Task<ConsumativeDeleteViewModel> GetForDeleteAsync(string id);

        Task<bool> ExistsByIdAsync(string id);

        Task<bool> ExistsByNameAsync(string name);

        Task<string> GetCurrentNameAsync(string id);
    }
}
