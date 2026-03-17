using System.ComponentModel.DataAnnotations;

namespace MyBakery.WepApi.Entity.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
