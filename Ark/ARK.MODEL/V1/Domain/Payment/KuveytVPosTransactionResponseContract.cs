namespace ARK.MODEL.V1.Domain.Payment
{
    public class VPosTransactionResponseContract
    {
        public string ACSURL { get; set; }
        public string AuthenticationPacket { get; set; }
        public string HashData { get; set; }
        public bool IsEnrolled { get; set; }
        public bool IsVirtual { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string OrderId { get; set; }
        public System.DateTime TransactionTime { get; set; }
        public string MerchantOrderId { get; set; }
        public string ReferenceId { get; set; }
        public bool IsSuccess { get; }
        public string BusinessKey { get; set; }
        public string MD { get; set; }
        public string PareqHtmlFormString { get; set; }
        public string Password { get; set; }
        public string ProvisionNumber { get; set; }
        public string RRN { get; set; }
        public string SafeKey { get; set; }
        public string Stan { get; set; }
        public string TransactionType { get; set; }
        public VPosMessage VPosMessage { get; set; }
    }
    public class VPosMessage
    {
        public decimal Amount { get; set; }
    }
}
