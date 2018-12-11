namespace BA.UI.WebV2.Models
{
    public class SubMenuVm
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        public string Name { get; set; }
        public string UrlAction { get; set; }
    }
}
