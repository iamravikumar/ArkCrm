using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models //bucak
{
    public class AddressTownship : BaseModel.ServiceBaseData
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }
        public int? QueueNo { get; set; } //sıra no


        public int? DistrictCode { get; set; }
        public int? DistrictId { get; set; }
        public AddressDistrict District { get; set; }


        //<Kod>747</Kod>
        //<Ad>MERKEZ</Ad>
        //<Ad2 xsi:nil="true"/>
        //<EskiAd xsi:nil="true"/>
        //<IlceKodu>1663</IlceKodu>
        //<SiraNo>0</SiraNo>
        //<Durum>1</Durum>
        //<KarsilikKod xsi:nil="true"/>
        //<SurumNo>0</SurumNo>
        //<GuncellemeZamani>2010-05-04T21:00:00.000Z</GuncellemeZamani>
    }
}
