using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HousingHack.Handler.Entity;

namespace HousingHack.Handler
{
    public class HousingHackDb : DbContext
    {
        public HousingHackDb()
            : base("name=HousingHack")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Venture> Ventures { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<VentureInvestment> VentureInvestments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
