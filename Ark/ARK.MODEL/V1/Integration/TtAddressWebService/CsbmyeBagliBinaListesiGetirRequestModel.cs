namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class CsbmyeBagliBinaListesiGetirRequestModel : RequestModel
    {
        public long CSBMKodu { get; set; }
        public System.Nullable<long> SayfaNo { get; set; }
        public bool SayfaNoSpecified { get; set; }
    }
}
