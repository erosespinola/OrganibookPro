using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organibook.Models
{
    public class Book
    {
        public int Id { set; get; }
        public String Name { set; get; }
        public String Isbn { set; get; }
        public Student Student { get; set; }
    }
}