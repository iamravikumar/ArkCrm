namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class IlceGetirResponseModel : ResponseModel
    {
        public TTAIlceModel Ilce { get; set; }
        public long AdresEnBuyukSurumNo { get; set; }
        public bool AdresEnBuyukSurumNoSpecified { get; set; }
    }
}
