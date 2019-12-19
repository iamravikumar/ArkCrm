using System;

namespace ARK.MODEL.V1.Domain.User
{
    public class TokenModel
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Token { get; set; }
    }
}
