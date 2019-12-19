using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models //köy
{
    public class AddressVillage : BaseModel.ServiceBaseData
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }
        public int? QueueNo { get; set; } //sıra no

        public int? TownshipCode { get; set; }
        public int? TownshipId { get; set; }
        public AddressTownship Township { get; set; }
        //<Kod>16693</Kod>
        //<Ad>MERKEZ</Ad>
        //<Ad2 xsi:nil="true"/>
        //<EskiAd xsi:nil="true"/>
        //<BucakKodu>747</BucakKodu>
        //<SiraNo>0</SiraNo>
        //<Durum>1</Durum>
        //<KarsilikKod xsi:nil="true"/>
        //<SurumNo>0</SurumNo>
        //<GuncellemeZamani>2010-05-04T21:00:00.000Z</GuncellemeZamani>
    }
}
