using System.Collections.Generic;

namespace ARK.MODEL.V1.Domain.Sms
{
    public class NetgsmSmsRequest : ISmsModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public MessageModel[] Messages { get; set; }
        public string SourceAttr { get; set; }
    }
}
