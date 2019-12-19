namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class TamAdresGetirResponseModel : ResponseModel
    {
        public TamAdresNesnesiModel TamAdres { get; set; }
        public long AdresEnBuyukSurumNo { get; set; }
        public bool AdresEnBuyukSurumNoSpecified { get; set; }
    }
}
