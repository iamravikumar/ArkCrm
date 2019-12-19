using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class MikrotikIP : BaseModel.BaseData // local ip - iç ip adresi ekle
    {
        public int ID { get; set; }
        [MaxLength(50)]
        public string IP { get; set; }
        public int? MikrotikId { get; set; }
        public Mikrotik Mikrotik { get; set; }
    }
}
