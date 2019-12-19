using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class AddressCity : BaseModel.ServiceBaseData
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }

        public int? NationalityCode { get; set; }
        public int? NationalityId { get; set; }
        public AddressNationality Nationality { get; set; }

        //        <Kod>1</Kod>
        //<Ad>ADANA</Ad>
        //<Ad2 xsi:nil="true"/>
        //<EskiAd xsi:nil="true"/>
        //<UlkeKodu>1</UlkeKodu>
        //<Durum>1</Durum>
        //<SurumNo>0</SurumNo>
        //<GuncellemeZamani>2010-05-04T21:00:00.000Z</GuncellemeZamani>
    }
}
