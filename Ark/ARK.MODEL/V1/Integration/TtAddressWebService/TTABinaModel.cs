namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class TTABinaModel
    {
        public long Kod { get; set; }
        public string DisKapiNo { get; set; }
        public string SiteAdi { get; set; }
        public string SiteAdi2 { get; set; }
        public string SiteEskiAdi { get; set; }
        public string BlokAdi { get; set; }
        public string BlokAdi2 { get; set; }
        public string BlokEskiAdi { get; set; }
        public long CSBMKodu { get; set; }
        public short Nitelik { get; set; }
        public string PostaKodu { get; set; }
        public System.Nullable<long> EsBinaKodu { get; set; }
        public long Durum { get; set; }
        public System.Nullable<long> KarsilikKod { get; set; }
        public long SurumNo { get; set; }
        public System.DateTime GuncellemeZamani { get; set; }
    }
}