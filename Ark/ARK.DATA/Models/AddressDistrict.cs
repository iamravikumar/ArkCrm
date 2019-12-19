using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class AddressDistrict : BaseModel.ServiceBaseData
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }

        public int? CityCode { get; set; }
        public int? CityId { get; set; }
        public AddressCity City { get; set; }

        //<Kod>1103</Kod>
        //<Ad>ADALAR</Ad>
        //<Ad2 xsi:nil="true"/>
        //<EskiAd xsi:nil="true"/>
        //<IlKodu>34</IlKodu>
        //<Durum>1</Durum>
        //<KarsilikKod xsi:nil="true"/>
        //<SurumNo>0</SurumNo>
        //<GuncellemeZamani>2010-05-04T21:00:00.000Z</GuncellemeZamani>
    }
}
