using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentricTeam2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CentricTeam2.DAL
{
    public class Context : DbContext
    {
        public Context(): base("name=cs4200")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DAL.Context,CentricTeam2.Migrations.Context.Configuration>("cs4200"));

        }
        public System.Data.Entity.DbSet<CentricTeam2.Models.UserDetails> userDetails { get; set; }

        public DbSet<Recognition> Recognition { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<CentricTeam2.Models.EmployeeRecognition> EmployeeRecognitions { get; set; }
    }
}