namespace AirsoftWebStore.Services.Models.Gun
{
    using AirsoftWebStore.Web.ViewModels.Gun;

    public class AllGunsFilteredAndPagedServiceModel
    {
        public AllGunsFilteredAndPagedServiceModel()
        {
            this.Guns = new HashSet<GunAllViewModel>();
        }

        public int TotalGunsCount { get; set; }

        public IEnumerable<GunAllViewModel> Guns { get; set; } = null!;
    }
}
