using Organibook.Models;
using Organibook.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Organibook.Controllers
{
    public class IsbnController : ApiController
    {

        private BookFetcher webapi = new BookFetcher
        {
            Key = "VEYO0O89"
        };

        // GET api/isbn/5
        public Book Get(String id)
        {
            return webapi.getBook(id);
        }

    }
}
