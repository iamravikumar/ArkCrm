namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class BucagaBagliKoyListesiGetirRequestModel : RequestModel
    {
        public long BucakKodu { get; set; }
        public System.Nullable<long> SayfaNo { get; set; }
        public bool SayfaNoSpecified { get; set; }
    }
}
