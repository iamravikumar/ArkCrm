namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class CSBMGetirResponseModel : ResponseModel
    {
        public TTACSBMModel Csbm { get; set; }
        public long AdresEnBuyukSurumNo { get; set; }
        public bool AdresEnBuyukSurumNoSpecified { get; set; }
    }
}
