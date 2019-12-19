namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    class BagimsizBolumGetirResponseModel : ResponseModel
    {
        public TTABagimsizBolumModel BagimsizBolum { get; set; }
        public long AdresEnBuyukSurumNo { get; set; }
        public bool AdresEnBuyukSurumNoSpecified { get; set; }
    }
}
