namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class KoyeBagliMahalleListesiGetirRequestModel : RequestModel
    {
        public long KoyKodu { get; set; }
        public System.Nullable<long> SayfaNo { get; set; }
        public bool SayfaNoSpecified;
    }
}