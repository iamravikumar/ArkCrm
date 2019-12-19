namespace ARK.MODEL.V1.Domain.Sms
{
    public class VerimorSmsRequest : ISmsModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SourceAttr { get; set; }
        public MessageModel[] Messages { get; set; }
    }
}
