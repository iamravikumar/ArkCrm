using ARK.MODEL.V1.Domain.Retailer;
using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Mikrotik
{
    public class MikrotikModel : BaseModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string IPAddress { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Secret { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        public int? RetailerId { get; set; }
        public RetailerModel Retailer { get; set; }
    }
}