using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models //belediyeler
{
    public class AddressMunicipality : BaseModel.ServiceBaseData
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

        //<Kod>34023</Kod>
        //<IlKodu>34</IlKodu>
        //<Ad>ADALAR</Ad>
        //<Durum>1</Durum>
        //<SurumNo>0</SurumNo>
        //<GuncellemeZamani>2011-03-04T14:24:24.000Z</GuncellemeZamani>
    }
}
