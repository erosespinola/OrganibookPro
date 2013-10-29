using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Organibook.Models
{
    public class OrganibookContext : DbContext
    {
        public DbSet<Book> Books { get; set; } 
    }
}