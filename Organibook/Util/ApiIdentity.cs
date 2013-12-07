using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using Organibook.Models;

namespace Organibook.Util
{
    public class ApiIdentity : IIdentity
    {
        public User User { get; set; }

        public ApiIdentity(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            this.User = user;
        }

        public string Name
        {
            get { return this.User.Username; }
        }

        public string AuthenticationType
        {
            get { return "Basic"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }
    }
}