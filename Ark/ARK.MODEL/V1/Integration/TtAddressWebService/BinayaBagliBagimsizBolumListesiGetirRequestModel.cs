namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class BinayaBagliBagimsizBolumListesiGetirRequestModel : RequestModel
    {
        public long BinaKodu { get; set; }
        public System.Nullable<long> SayfaNo { get; set; }
        public bool SayfaNoSpecified { get; set; }
    }
}
