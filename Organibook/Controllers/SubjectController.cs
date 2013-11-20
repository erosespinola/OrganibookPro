using Organibook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Organibook.Controllers
{
    public class SubjectController : ApiController
    {
        private OrganibookContext db = new OrganibookContext();

        // GET api/subject
        public IEnumerable<Subject> Get()
        {
            return db.Subjects;
        }

        // GET api/subject/5
        public Subject Get(int id)
        {
            return (from v in db.Subjects
                    where v.Id == id
                    select v).Single();
        }

        // POST api/subject
        public void Post([FromBody]Subject subject)
        {
            db.Subjects.Add(subject);
            db.SaveChanges();
        }

        // PUT api/subject/5
        public void Put(int id, [FromBody]Subject subject)
        {
            Subject s = (from v in db.Subjects
                         where v.Id == id
                         select v).Single();
            s.Name = subject.Name;
            db.SaveChanges();
        }

        // DELETE api/subject/5
        public void Delete(int id)
        {
            Subject s = (from v in db.Subjects
                         where v.Id == id
                         select v).Single();
            db.Subjects.Remove(s);
            db.SaveChanges();
        }
    }
}
