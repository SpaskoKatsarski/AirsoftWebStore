namespace AirsoftWebStore.Services.Models.Part
{
    using AirsoftWebStore.Web.ViewModels.Part;

    public class AllPartsFilteredAndPagedServiceModel
    {
        public AllPartsFilteredAndPagedServiceModel()
        {
            this.Parts = new HashSet<PartAllViewModel>();
        }

        public int TotalPartsCount { get; set; }

        public IEnumerable<PartAllViewModel> Parts { get; set; } = null!;
    }
}
