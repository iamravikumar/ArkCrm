using System;
using System.Collections.Generic;
using System.Text;

namespace ARK.CORE.Shared
{
    [Serializable]
    public class AccessToken
    {
        public AccessToken Data { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }
        public string UserIdentification { get; set; }
        public long? ServicePlaceId { get; set; }
        public string ServicePlaceName { get; set; }
        public long? ServicePlaceCategoryId { get; set; }
        public long? ServicePlaceType { get; set; }
        public int RetailerId { get; internal set; }
        public object RetailerName { get; internal set; }
        public int RetailerType { get; internal set; }
    }
}
