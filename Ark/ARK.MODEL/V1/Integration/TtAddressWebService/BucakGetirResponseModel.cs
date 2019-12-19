namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class BucakGetirResponseModel : ResponseModel
    {
        public TTABucakModel Bucak { get; set; }   
        public long AdresEnBuyukSurumNo { get; set; }
        public bool AdresEnBuyukSurumNoSpecified { get; set; }
    }
}
