namespace ARK.CORE.Shared
{
   public class SessionInfo
    {
        public AccessToken TokenObj { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public long? UserId { get; set; }
        public string UserIdentification { get; set; }
        public string Token { get; set; }
        public int? RoleCode { get; set; }


        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get { return string.Format("{0} {1}", Name, Surname); } }
        public int UserType { get; set; }
        public int Id { get; set; }
        public bool LoginCompleted { get; set; }
        public object RetailerId { get; internal set; }
        public object RetailerName { get; internal set; }
        public int RetailerType { get; internal set; }
    }
}
