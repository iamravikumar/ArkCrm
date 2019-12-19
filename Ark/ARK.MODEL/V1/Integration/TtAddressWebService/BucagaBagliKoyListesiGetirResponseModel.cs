namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class BucagaBagliKoyListesiGetirResponseModel : ResponseModel
    {
        public TTAKoyModel[] BucagaBagliKoyListesi { get; set; }
        public long ToplamSayfa { get; set; }
    }
}
