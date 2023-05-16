using Microsoft.AspNetCore.Http;


namespace Traversal.Areas.Admin.Models
{
    public class AddGuideViewModel
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string Description { get;set; }
    }
}
