namespace AirsoftWebStore.Services.Models.Consumative
{
    using AirsoftWebStore.Web.ViewModels.Consumative;

    public class AllConsumativesFilteredAndSortedServiceModel
    {
        public AllConsumativesFilteredAndSortedServiceModel()
        {
            this.Consumatives = new HashSet<ConsumativeAllViewModel>();
        }

        public int TotalConsumativesCount { get; set; }

        public IEnumerable<ConsumativeAllViewModel> Consumatives { get; set; } = null!;
    }
}
