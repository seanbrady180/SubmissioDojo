using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using SubmissionDojo.Models;

namespace SubmissionDojo.DAL
{
    public class DojoContext : DbContext
    {
        public DojoContext() : base("DojoContext") { }

        public DbSet<JiuJitsu> JiuJitsu { get; set; }
        public DbSet<Wrestling> Wrestling { get; set; }
        public DbSet<Judo> Judo { get; set; }
        public DbSet<NoGI> NoGi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}