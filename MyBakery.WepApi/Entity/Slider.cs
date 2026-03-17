using MyBakery.WepApi.Entity.Common;

namespace MyBakery.WepApi.Entity
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }

    }
}
