namespace DbRate.Migrations
{
    using DbRate.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DbRate.RateContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbRate.RateContext context)
        {
            //  This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.


              context.DbRateItems.AddOrUpdate(
                new DbRateItem { From = "EUR", To= "RUR", Rate = 60.6250 },
                new DbRateItem { From = "EUR", To = "UAH", Rate = 21.0000 },
                new DbRateItem { From = "EUR", To = "USD", Rate = 1.1412 },

                new DbRateItem { From = "RUR", To = "EUR", Rate = 0.0138 },
                new DbRateItem { From = "RUR", To = "UAH", Rate = 0.3200 },
                new DbRateItem { From = "RUR", To = "USD", Rate = 0.0171 },

                new DbRateItem { From = "UAH", To = "RUR", Rate = 3.4483 },
                new DbRateItem { From = "UAH", To = "EUR", Rate = 0.0515 },
                new DbRateItem { From = "UAH", To = "USD", Rate = 0.0629 },

                new DbRateItem { From = "USD", To = "RUR", Rate = 49.6875 },
                new DbRateItem { From = "USD", To = "UAH", Rate = 17.0000 },
                new DbRateItem { From = "USD", To = "EUR", Rate = 0.7571 }

              );

        }
    }
}
