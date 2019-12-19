using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class AddressBuilding : BaseModel.ServiceBaseData
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }// dis kapi no
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }

        [MaxLength(256)]
        public string SiteName { get; set; }
        [MaxLength(256)]
        public string SiteName2 { get; set; }
        [MaxLength(256)]
        public string SiteOldName { get; set; }

        [MaxLength(256)]
        public string BlockName { get; set; }
        [MaxLength(256)]
        public string BlockName2 { get; set; }
        [MaxLength(256)]
        public string OldBlockName { get; set; }

        [MaxLength(16)]
        public string PostCode { get; set; }
        public int? OldBuildingCode { get; set; }//EsBinaKodu
        public int? CsbmCode { get; set; }
        public int? CsbmId { get; set; }
        public AddressCsbm Csbm { get; set; }

        public int? BuildingTypeId { get; set; }
        public AddressBuildingType BuildingType { get; set; }

        //<Kod>28513849</Kod>
        //<DisKapiNo>10 A</DisKapiNo>

        //<SiteAdi xsi:nil="true"/>
        //<SiteAdi2 xsi:nil="true"/>
        //<SiteEskiAdi xsi:nil="true"/>

        //<BlokAdi>SIRMA KEŞ IŞ HANI</BlokAdi>
        //<BlokAdi2 xsi:nil= "true" />
        //< BlokEskiAdi xsi:nil= "true" />

        //< CSBMKodu > 789926 </ CSBMKodu >
        //< Nitelik > 2 </ Nitelik >
        //< PostaKodu xsi:nil= "true" />
        //< EsBinaKodu > 17608731 </ EsBinaKodu >
        //< Durum > 1 </ Durum >
        //< KarsilikKod xsi:nil= "true" />
        //< SurumNo > 16205807 </ SurumNo >
        //< GuncellemeZamani > 2013 - 02 - 18T13:30:03.000Z</GuncellemeZamani>
    }
}