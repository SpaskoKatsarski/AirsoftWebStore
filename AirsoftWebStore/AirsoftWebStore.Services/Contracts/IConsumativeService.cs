namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Models.Consumative;
    using AirsoftWebStore.Web.ViewModels.Consumative;

    public interface IConsumativeService
    {
        Task<Consumative> GetConsumativeByIdAsync(string id);

        Task<AllConsumativesFilteredAndSortedServiceModel> AllAsync(AllConsumativesQueryModel queryModel);

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
