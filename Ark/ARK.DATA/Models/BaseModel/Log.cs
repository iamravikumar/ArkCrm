namespace ARK.DATA.Models.BaseModel
{
    public class Log
    {        
        public string MethodName { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string Exception { get; set; }
        public int? CreateDate { get; set; }
        public int? CreateUser { get; set; }
    }
}
