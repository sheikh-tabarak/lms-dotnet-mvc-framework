using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TL_LMS.Models
{
    public class AllDataContext:DbContext
    {
        public AllDataContext() : base("name=LMS2Entities2") { }

        public DbSet<Student> students { get; set; }

        public DbSet<Teacher> teachers { get; set; }

        public DbSet<Cours> courses { get; set; }

        public DbSet<Registration> registrations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AllDataContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}