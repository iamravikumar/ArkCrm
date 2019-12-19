namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class KoyeBagliMahalleListesiGetirResponseModel : ResponseModel
    {
        public TTAMahalleModel[] KoyeBagliMahalleListesi { get; set; }
        public long ToplamSayfa { get; set; }
    }
}
