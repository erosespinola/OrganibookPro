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
    public class SaleController : ApiController
    {
        private OrganibookContext db = new OrganibookContext();

        // GET api/sale
        public IEnumerable<Sale> Get()
        {
            return db.Sales;
        }

        // GET api/sale/5
        public Sale Get(int id)
        {
            return (from v in db.Sales
                    where v.Id == id
                    select v).Single();
        }

        // POST api/sale
        public void Post([FromBody]Sale sale)
        {
            db.Sales.Add(sale);
            db.SaveChanges();
        }

        // PUT api/sale/5
        public void Put(int id, [FromBody]Sale sale)
        {
            Sale s = (from v in db.Sales
                         where v.Id == id
                         select v).Single();
            s.Book = sale.Book;
            s.Date = sale.Date;
            db.SaveChanges();
        }

        // DELETE api/sale/5
        public void Delete(int id)
        {
            Sale s = (from v in db.Sales
                         where v.Id == id
                         select v).Single();
            db.Sales.Remove(s);
            db.SaveChanges();
        }
    }
}
