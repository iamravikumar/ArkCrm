using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class Mikrotik : BaseModel.BaseData
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string IPAddress { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Secret { get; set; } //radius secret
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        
        public int? RetailerId { get; set; }
        public Retailer Retailer { get; set; }
    }
}
