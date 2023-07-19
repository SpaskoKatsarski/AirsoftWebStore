namespace AirsoftWebStore.Services.Models.Equipment
{
    using AirsoftWebStore.Web.ViewModels.Equipment;

    public class AllEquipmentFilteredAndPagedServiceModel
    {
        public AllEquipmentFilteredAndPagedServiceModel()
        {
            this.AllEquipment = new HashSet<EquipmentAllViewModel>();
        }

        public int TotalEquipmentCount { get; set; }

        public IEnumerable<EquipmentAllViewModel> AllEquipment { get; set; } = null!;
    }
}
