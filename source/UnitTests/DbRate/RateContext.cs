using DbRate.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRate
{
    public class RateContext : DbContext
    {
        public IDbSet<DbRateItem> DbRateItems { get; set; }

        public RateContext()
            : base("Default")
        {
            Database.SetInitializer<RateContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new DbRateItemConfiguration());
        }
    }
}
