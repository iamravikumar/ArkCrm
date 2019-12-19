namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class MahalleyeBagliCsbmListesiGetirRequestModel : RequestModel
    {
        public long MahalleKodu { get; set; }
        public System.Nullable<long> SayfaNo { get; set; }
        public bool SayfaNoSpecified { get; set; }
    }
}
