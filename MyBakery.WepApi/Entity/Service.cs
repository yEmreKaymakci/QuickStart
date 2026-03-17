using MyBakery.WepApi.Entity.Common;

namespace MyBakery.WepApi.Entity
{
    public class Service : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }

    }
}
