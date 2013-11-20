using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organibook.Models
{
    public class Sale
    {
        public int Id { set; get; }
        public DateTime Date { set; get; }
        public Book Book { set; get; }
    }
}