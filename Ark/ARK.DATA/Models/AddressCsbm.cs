using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class AddressCsbm : BaseModel.ServiceBaseData
    {
        public int ID { get; set; }
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string Name2 { get; set; }
        [MaxLength(128)]
        public string OldName { get; set; }

        public int? CsbmTypeId { get; set; }
        public AddressCsbmType CsbmType { get; set; }
        public int? QuarterCode { get; set; }
        public int? QuarterId { get; set; }
        public AddressQuarter Quarter { get; set; }

        //<Kod>789926</Kod>
        //<Ad>ABIHAYAT</Ad>
        //<Ad2 xsi:nil="true"/>
        //<EskiAd xsi:nil="true"/>
        //<MahalleKodu>40325</MahalleKodu>
        //<Tipi>4</Tipi>
        //<Durum>1</Durum>
        //<KarsilikKod xsi:nil="true"/>
        //<SurumNo>0</SurumNo>
        //<GuncellemeZamani>2010-05-04T21:00:00.000Z</GuncellemeZamani>
    }
}
