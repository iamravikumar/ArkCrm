using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class AddressBB : BaseModel.ServiceBaseData
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }
        public int? Code { get; set; } //bbkcode
        public int? IndoorNo { get; set; }//IcKapiNo
        public int? BuildingNo { get; set; } //UAVT - Bina no


        public int? BBTypeId { get; set; }
        public AddressBBType BBType { get; set; }
        public int? BuildingCode { get; set; }
        public int? BuildingId { get; set; }
        public AddressBuilding Building { get; set; }

        //<Kod>17640638</Kod>
        //<IcKapiNo>7</IcKapiNo>
        //<AdresNo>2239618073</AdresNo>
        //<BinaKodu>18177912</BinaKodu>
        //<Nitelik>1</Nitelik>
        //<Durum>1</Durum>
        //<KarsilikKod xsi:nil="true"/>
        //<SurumNo>0</SurumNo>
        //<GuncellemeZamani>2010-05-04T21:00:00.000Z</GuncellemeZamani>
    }
}
