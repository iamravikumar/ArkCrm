namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class CsbmyeBagliBinaListesiGetirResponseModel : ResponseModel
    {
        public TTABinaModel[] CsbmyeBagliBinaListesi { get; set; }
        public long ToplamSayfa { get; set; }
    }
}
