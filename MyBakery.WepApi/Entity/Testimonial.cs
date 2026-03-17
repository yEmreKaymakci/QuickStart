using MyBakery.WepApi.Entity.Common;

namespace MyBakery.WepApi.Entity
{
    public class Testimonial : BaseEntity
    {
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public string ImageUrl { get; set; }
    }
}
