using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class MikrotikLine : BaseModel.BaseData
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string IPAddress { get; set; } //metro - dsl ip adresi dış ip
        [MaxLength(50)]
        public string BalanceName { get; set; }
        public int PortRange { get; set; } // port aralık - 400        
        public int PortStart { get; set; } //1
        public int PortEnd { get; set; } //65000

        public int? TypeId { get; set; }
        public MikrotikLineType Type { get; set; }
        public int? MikrotikId { get; set; }
        public Mikrotik Mikrotik { get; set; }
    }
}
