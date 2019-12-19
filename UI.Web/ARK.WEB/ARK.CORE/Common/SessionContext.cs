using ARK.CORE.Shared;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ARK.CORE.Common
{
    [Serializable]
    public class SessionContext
    {
        public SessionContext()
        {
            ActiveUser = new SessionInfo();
        }
        private static IHttpContextAccessor _httpContextAccessor;
        private static ISession _session => _httpContextAccessor.HttpContext.Session;
        public SessionInfo ActiveUser { get; private set; }

        public SessionContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            ActiveUser = new SessionInfo();
        }


        public static SessionContext Current => JsonConvert.DeserializeObject<SessionContext>(_session.GetString("SessionContext"));


        public static bool IsSessionNull()
        {
            if (Current == null)
                return true;
            if (_session.GetString("SessionContext") != null) return false;
            //var cm = new CacheManager();
            //if (!cm.IsExists("Session-" + HttpContext.Current.Session.SessionID)) return true;
            //var cacheObj = cm.Get<HttpSessionState>("Session-" + HttpContext.Current.Session.SessionID);
            //foreach (var key in cacheObj.Keys)
            //    HttpContext.Current.Session[key.ToString()] = cacheObj[key.ToString()];
            return false;
        }

        //TODO: IP
        //public static string GetRequestIp()
        //{
        //    //The X-Forwarded-For (XFF) HTTP header field is a de facto standard for identifying the originating IP address of a 
        //    //client connecting to a web server through an HTTP proxy or load balancer
        //    string ip = Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //    if (string.IsNullOrEmpty(ip))
        //        ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

        //    return ip;
        //}

        public static bool IsLoginCompleted()
        {
            return _session.GetString("SessionContext") != null && Current.ActiveUser.LoginCompleted;
        }

        //TODO: VerifyIp
        //public static bool VerifyIp()
        //{
        //    if (_session.GetString("SessionContext") == null) return false;
        //    if (!Current.ActiveUser.LoginCompleted) return false;
        //    var clientIp = Utils.GetRequestIp();
        //    return clientIp == Current.ActiveUser.ClientIp;
        //}

        public static SessionContext StartSession(string token)
        {
            //clear current user object
            _session.SetString("SessionContext", null);
            AccessToken tokenObj = JsonConvert.DeserializeObject<AccessToken>(token);

            //LoginThrowException(TokenObj);
            var session = new SessionContext
            {
                ActiveUser =
                    {
                        RoleName = tokenObj.Data.RoleName,
                        TokenObj = tokenObj.Data,
                        UserId = tokenObj.Data.UserId,
                        UserIdentification = tokenObj.Data.UserIdentification,
                        Email = tokenObj.Data.Email,
                        Token=tokenObj.Data.Token,
                        RetailerId = tokenObj.Data.RetailerId != 0 ? tokenObj.Data.RetailerId:0,
                        RetailerName = tokenObj.Data.RetailerName,
                        RetailerType = tokenObj.Data.RetailerType != 0 ? tokenObj.Data.RetailerType : 0
                    }
            };
            // HttpContext.Session.SetString("", "The Doctor");
            return session;
        }

        //private static void LoginThrowException(AccessToken control)
        //{
        //    //List<int> placeIdNullRoleCodes = new List<int> { 1, 2, 3, 4, 5, 6, 17, 19 };
        //    //if (!placeIdNullRoleCodes.Contains(control.rolecode.ToInt()) && (control.placeId.IsNull() || control.placeId <= 0))
        //    //    throw new Exception("Kullanıcının firma bilgisi bulunamadı");
        //    //List<int> cityIdNotNullCodes = new List<int> { 5, 6, 17 };
        //    //if (cityIdNotNullCodes.Contains(control.rolecode.ToInt()) && (control.cityId.IsNull() || control.cityId <= 0))
        //    //    throw new Exception("Tarım Bakanlığı Taşra kullanıcısının şehir bilgisi bulunamadı");
        //}

        public static void AbandonSession()
        {
            _session.Clear();
            _session.Remove("SessionContext");
        }
    }
}