namespace ARK.MODEL.V1.Integration.TtAddressWebService
{
    public class BinayaBagliBagimsizBolumListesiGetirResponseModel : ResponseModel
    {
        public TTABagimsizBolumModel[] BinayaBagliBagimsizBolumListesi { get; set; }
        public long ToplamSayfa { get; set; }
    }
}
