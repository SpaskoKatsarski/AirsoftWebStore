namespace AirsoftWebStore.Web.ViewModels.Gun
{
    using System.ComponentModel.DataAnnotations;

    using AirsoftWebStore.Web.ViewModels.Gun.Enums;
    using static AirsoftWebStore.Common.GeneralApplicationConstants;

    public class AllGunsQueryModel
    {
        public AllGunsQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.GunsPerPage = EntitiesPerPage;
            this.Categories = new HashSet<string>();
            this.Guns = new HashSet<GunAllViewModel>();
        }

        public string? Category { get; set; }

        [Display(Name = "Search by Model")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Replicas by")]
        public GunSorting GunSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Items per Page")]
        public int GunsPerPage { get; set; }

        public int TotalGuns { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<GunAllViewModel> Guns { get; set; } = null!;
    }
}
