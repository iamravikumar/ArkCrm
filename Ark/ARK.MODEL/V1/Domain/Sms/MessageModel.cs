namespace ARK.MODEL.V1.Domain.Sms
{
    public class MessageModel
    {
        public string Message { get; set; }
        public string Destination { get; set; }

        public MessageModel() { }

        public MessageModel(string message, string destination)
        {
            this.Message = message;
            this.Destination = destination;
        }
    }
}
