namespace AirsoftWebStore.Web.ViewModels.Part
{
    using System.ComponentModel.DataAnnotations;

    using AirsoftWebStore.Web.ViewModels.Part.Enums;
    using static AirsoftWebStore.Common.GeneralApplicationConstants;

    public class AllPartsQueryModel
    {
        public AllPartsQueryModel()
        {
            CurrentPage = DefaultPage;
            PartsPerPage = EntitiesPerPage;
            Categories = new HashSet<string>();
            Parts = new HashSet<PartAllViewModel>();
        }

        public string? Category { get; set; }

        [Display(Name = "Search by Name")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Parts by")]
        public PartSorting PartSorting { get; set; }

        [Display(Name = "Items per Page")]
        public int PartsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalParts { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<PartAllViewModel> Parts { get; set; } = null!;
    }
}
