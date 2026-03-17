using MyBakery.WepApi.Entity.Common;

namespace MyBakery.WepApi.Entity
{
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
    }
}
