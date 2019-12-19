namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class KoyGetirResponseModel : ResponseModel
    {
        public TTAKoyModel Koy { get; set; }
        public long AdresEnBuyukSurumNo { get; set; }
        public bool AdresEnBuyukSurumNoSpecified { get; set; }
    }
}
