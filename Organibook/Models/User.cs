using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organibook.Models
{
    public class User
    {
        enum Roles { Admin = 0, Seller }

        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Role { get; set; }
    }
}