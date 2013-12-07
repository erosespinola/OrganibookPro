using Organibook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Organibook.Util
{
    public class BasicAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        private OrganibookContext db = new OrganibookContext();

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                // Get the authentication token from header
                string authToken = Encoding.UTF8.GetString(Convert.FromBase64String(actionContext.Request.Headers.Authorization.Parameter));
                string username = authToken.Substring(0, authToken.IndexOf(":"));
                string password = authToken.Substring(authToken.IndexOf(":") + 1);

                // Get user from db
                User user = (from v in db.Users
                    where v.Username == username
                    && v.Password == password
                    select v).Single();

                if (user != null)
                {
                    HttpContext.Current.User = new GenericPrincipal(new ApiIdentity(user), new string[] { });
                    base.OnActionExecuting(actionContext);
                }
                else 
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}