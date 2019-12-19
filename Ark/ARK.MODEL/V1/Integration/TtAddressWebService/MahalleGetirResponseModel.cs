namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class MahalleGetirResponseModel : ResponseModel
    {
        public TTAMahalleModel Mahalle { get; set; }
        public long AdresEnBuyukSurumNo { get; set; }
        public bool AdresEnBuyukSurumNoSpecified { get; set; }
    }
}
