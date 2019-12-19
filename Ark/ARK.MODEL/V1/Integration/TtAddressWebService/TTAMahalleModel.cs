namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class TTAMahalleModel
    {
        public long Kod { get; set; }
        public string Ad { get; set; }
        public string Ad2 { get; set; }
        public string EskiAd { get; set; }
        public long KoyKodu { get; set; }
        public short Tipi { get; set; }
        public System.Nullable<long> YetkiliIdareKodu { get; set; }
        public System.Nullable<long> BelediyeKodu { get; set; }
        public long Durum { get; set; }
        public System.Nullable<long> KarsilikKod { get; set; }
        public long SurumNo { get; set; }
        public System.DateTime GuncellemeZamani { get; set; }
    }
}
