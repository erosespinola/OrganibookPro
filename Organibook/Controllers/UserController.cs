using Organibook.Models;
using Organibook.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Organibook.Controllers
{
    public class UserController : ApiController
    {
        private OrganibookContext db = new OrganibookContext();

        // GET api/user
        public IEnumerable<User> Get()
        {
            return db.Users;
        }

        // GET api/user/5
        public User Get(int id)
        {
            return (from v in db.Users
                    where v.Id == id
                    select v).Single();
        }

        // POST api/user
        public void Post([FromBody]User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]User user)
        {
            User u = (from v in db.Users
                      where v.Id == id
                      select v).Single();
            u.Username = user.Username;
            u.Password = user.Password;
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.Role = user.Role;
            db.SaveChanges();
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
            User u = (from v in db.Users
                      where v.Id == id
                      select v).Single();
            db.Users.Remove(u);
            db.SaveChanges();
        }
    }
}
