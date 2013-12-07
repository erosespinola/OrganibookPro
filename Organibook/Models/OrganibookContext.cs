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
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public OrganibookContext() : base("azure") { }
    }
}