namespace ARK.MODEL.V1.Configuration
{
    public class WeblogConfiguration
    {
        public string ApplicationName { get; set; }
        public string ApplicationBasePath { get; set; } = "/";
        public string MongoDbConnection { get; set; }
        public int PostPageSize { get; set; } = 10000;
        public int HomePagePostCount { get; set; } = 30;
        public string PayPalEmail { get; set; }
        public EmailConfiguration Email { get; set; } = new EmailConfiguration();
    }

    public class EmailConfiguration
    {
        public string MailServer { get; set; }
        public string MailServerUsername { get; set; }
        public string MailServerPassword { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string AdminSenderEmail { get; set; }
    }
}
