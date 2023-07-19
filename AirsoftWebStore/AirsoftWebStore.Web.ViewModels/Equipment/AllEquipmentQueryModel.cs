namespace AirsoftWebStore.Web.ViewModels.Equipment
{
    using System.ComponentModel.DataAnnotations;

    using AirsoftWebStore.Web.ViewModels.Equipment.Enums;
    using static AirsoftWebStore.Common.GeneralApplicationConstants;

    public class AllEquipmentQueryModel
    {
        public AllEquipmentQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.ItemsPerPage = EntitiesPerPage;
            this.AllEquipment = new HashSet<EquipmentAllViewModel>();
        }

        [Display(Name = "Search by Name")]
        public string? SearchString { get; set; }

        [Display(Name = "Items per Page")]
        public int ItemsPerPage { get; set; }

        public EquipmentSorting EquipmentSorting { get; set; }

        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public IEnumerable<EquipmentAllViewModel> AllEquipment { get; set; } = null!;
    }
}
