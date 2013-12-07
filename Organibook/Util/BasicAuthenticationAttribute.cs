using Organibook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Security.Cryptography;

namespace Organibook.Util
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
        private OrganibookContext db = new OrganibookContext();

        /// <summary>
        /// Send the Authentication Challenge request
        /// </summary>
        /// <param name="message"></param>
        /// <param name="actionContext"></param>
        void Challenge(HttpActionContext actionContext)
        {
            var host = actionContext.Request.RequestUri.DnsSafeHost;
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", host));
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization == null)
            {
                Challenge(actionContext);
                return;
            }
            else
            {
                // Get the authentication token from header
                string authToken = Encoding.UTF8.GetString(Convert.FromBase64String(actionContext.Request.Headers.Authorization.Parameter));
                string username = authToken.Substring(0, authToken.IndexOf(":"));
                string password = authToken.Substring(authToken.IndexOf(":") + 1);

                password = CreateMD5Hash(password); 

                // Get user from db
                User user = (from v in db.Users
                             where v.Username == username
                             && v.Password == password
                             select v).SingleOrDefault();

                if (user != null)
                {
                    HttpContext.Current.User = new GenericPrincipal(new ApiIdentity(user), new string[] { });
                    base.OnActionExecuting(actionContext);
                }
                else 
                {
                    Challenge(actionContext);
                }
            }
        }

        public string CreateMD5Hash(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
                // To force the hex string to lower-case letters instead of
                // upper-case, use he following line instead:
                // sb.Append(hashBytes[i].ToString("x2")); 
            }
            return sb.ToString();
        }
    }
}