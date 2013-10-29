using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Organibook.Models;
using Organibook.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Organibook.Util
{
    public class BookController : ApiController
    {
        private OrganibookContext db = new OrganibookContext();
        

        // GET api/book
        public IEnumerable<Book> Get()
        {
            return db.Books;
        }

        // GET api/book/5
        public Book Get(string id)
        {
            return null;
        }

        // POST api/book
        public void Post([FromBody]Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        // PUT api/book/5
        public void Put(int id, [FromBody]Book book)
        {
            Book b = (from v in db.Books
                      where v.Id == id
                      select v).Single();
            b.Isbn = book.Isbn;
            b.Name = book.Name;
            db.SaveChanges();
        }

        // DELETE api/book/5
        public void Delete(int id)
        {
            Book b = (from v in db.Books
                      where v.Id == id
                      select v).Single();
            db.Books.Remove(b);
            db.SaveChanges();
        }
    }
}
