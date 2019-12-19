namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class MahalleyeBagliCsbmListesiGetirResponseModel : ResponseModel
    {
        public TTACSBMModel[] MahalleyeBagliCsbmListesi { get; set; }
        public long ToplamSayfa { get; set; }
    }
}
