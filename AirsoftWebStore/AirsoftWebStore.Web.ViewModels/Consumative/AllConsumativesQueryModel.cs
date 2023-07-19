namespace AirsoftWebStore.Web.ViewModels.Consumative
{
    using System.ComponentModel.DataAnnotations;

    using AirsoftWebStore.Web.ViewModels.Consumative.Enums;
    using static AirsoftWebStore.Common.GeneralApplicationConstants;

    public class AllConsumativesQueryModel
    {
        public AllConsumativesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.ConsumativesPerPage = EntitiesPerPage;
            this.Consumatives = new HashSet<ConsumativeAllViewModel>();
        }

        [Display(Name = "Search by Name")]
        public string? SearchString { get; set; }

        [Display(Name = "Items per Page")]
        public int ConsumativesPerPage { get; set; }

        [Display(Name = "Sort Items by")]
        public ConsumativeSorting ConsumativeSorting { get; set; }

        public int CurrentPage { get; set; }

        public int TotalConsumatives { get; set; }

        public IEnumerable<ConsumativeAllViewModel> Consumatives { get; set; } = null!;
    }
}
