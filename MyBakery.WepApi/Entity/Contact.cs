using MyBakery.WepApi.Entity.Common;

namespace MyBakery.WepApi.Entity
{
    public class Contact : BaseEntity
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MapUrl { get; set; }
    }
}
