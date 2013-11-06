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
        public String Publisher { get; set; }
        public String Author { get; set; }
        public Student Student { get; set; }
        public double Price { get; set; }
        
    }
}