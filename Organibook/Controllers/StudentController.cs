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
    public class StudentController : ApiController
    {
        private OrganibookContext db = new OrganibookContext();

        // GET api/student
        public IEnumerable<Student> Get()
        {
            return db.Students;
        }

        // GET api/student/5
        public Student Get(int id)
        {
            return (from v in db.Students
                    where v.Id == id
                    select v).Single();
        }

        // POST api/student
        public void Post([FromBody]Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        // PUT api/student/5
        public void Put(int id, [FromBody]Student student)
        {
            Student s = (from v in db.Students
                      where v.Id == id
                      select v).Single();
            s.Email = student.Email;
            s.Name = student.Name;
            s.StudentNumber = student.StudentNumber;
            db.SaveChanges();
        }

        // DELETE api/student/5
        public void Delete(int id)
        {
            Student s = (from v in db.Students
                      where v.Id == id
                      select v).Single();
            db.Students.Remove(s);
            db.SaveChanges();
        }
    }
}
