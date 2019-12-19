using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class AddressQuarter : BaseModel.ServiceBaseData //mahalle
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Name2 { get; set; }
        [MaxLength(256)]
        public string OldName { get; set; }
        [MaxLength(256)]
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }

        public int? MunicipalityCode { get; set; }
        public int? AuthorizedAdminCode { get; set; }
        public int QuarterTypeId { get; set; }
        public AddressQuarterType QuarterType { get; set; }
        public int? VillageCode { get; set; }
        public int? VillageId { get; set; }
        public AddressVillage Village { get; set; }



        //<Kod>40325</Kod>
        //<Ad>MİMAR KEMALETTİN</Ad>
        //<Ad2 xsi:nil= "true" />
        //< EskiAd xsi:nil= "true" />
        //< KoyKodu > 16658 </ KoyKodu >
        //< Tipi > 1 </ Tipi >
        //< YetkiliIdareKodu > 2270 </ YetkiliIdareKodu >
        //< BelediyeKodu > 34011 </ BelediyeKodu >
        //< Durum > 1 </ Durum >
        //< KarsilikKod xsi:nil= "true" />
        //< SurumNo > 0 </ SurumNo >
        //< GuncellemeZamani > 2010 - 05 - 04T21:00:00.000Z</GuncellemeZamani>
    }
}