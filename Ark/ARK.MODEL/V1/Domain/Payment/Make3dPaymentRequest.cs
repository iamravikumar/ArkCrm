namespace ARK.MODEL.V1.Domain.Payment
{
    public class Make3dPaymentRequest
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpireDateMonth { get; set; }
        public string CardExpireDateYear { get; set; }
        public string CardCVV2 { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
