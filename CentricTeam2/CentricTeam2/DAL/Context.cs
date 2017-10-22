using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentricTeam2.Models;
using System.Data.Entity;

namespace CentricTeam2.DAL
{
    public class Context : DbContext
    {
        public Context(): base("name=cs4200")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DAL.Context, CentricTeam2.Migrations.Context.Configuration>("cs4200"));

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<CentricTeam2.Models.UserDetails> UserDetails { get; set; }
    }
}