namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class BinaGetirResponseModel : ResponseModel
    {
        public TTABinaModel Bina { get; set; }
        public long AdresEnBuyukSurumNo { get; set; }
        public bool AdresEnBuyukSurumNoSpecified { get; set; }
    }
}
