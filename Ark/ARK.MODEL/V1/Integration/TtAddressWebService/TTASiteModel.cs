namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class TTASiteModel
    {
        public long Kod { get; set; }
        public string Ad { get; set; }
        public long MahalleKodu { get; set; }
        public System.DateTime GuncellemeZamani { get; set; }
        public string GuncelleyenKullanici { get; set; }
        public System.DateTime TanimlamaZamani { get; set; }
        public string TanimlayanKullanici { get; set; }
    }
}
