using HousingHack.Handler.Entity;

namespace HousingHack.Handler.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HousingHackDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HousingHackDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                /*context.Users.AddOrUpdate(
                  new User { Name = "Pavan", Email = "pavan@gmail.com", Password = "pavan", PhoneNumber = "9008066213", Type = "Admin"},
                  new User { Name = "Nikhil", Email = "nikhil@gmail.com", Password = "nikhil", PhoneNumber = "9738131081", Type = "User"},
                  new User { Name = "Adithya", Email = "adi@gmail.com", Password = "adi", PhoneNumber = "8105735531", Type = "User"},
                  new User { Name = "Anuj", Email = "anuj@gmail.com", Password = "anuj", PhoneNumber = "9742510299", Type = "Admin"}
                );*/
            /*context.Listings.AddOrUpdate(
                  new Listing { PropertyName = "Kaalepalya", EstimatedCost = "20 Lacs", AvailabilityType = "Buy", PropertyDescription = "2BHK, External Bathroom", Locality = "Kalasipalya", PropertyType = "House", UserId = 2, PhotoLinks = ""},
                  new Listing { PropertyName = "FarmLand", EstimatedCost = "12 Lacs / Acre", AvailabilityType = "Buy", PropertyDescription = "7 acres of uncultivated farm land", Locality = "Ramanagar", PropertyType = "Land", UserId = 1, PhotoLinks = "" },
                  new Listing { PropertyName = "Brindavan Apts. 301", EstimatedCost = "40,000 per month", AvailabilityType = "Rent", PropertyDescription = "3BHK Flat", Locality = "Sanjay Nagar", PropertyType = "House", UserId = 3, PhotoLinks = "" }
                );
            context.Ventures.AddOrUpdate(
                  new Venture { TotalInvestment = 40.0, Plans = "Monthly Dividends through rent", Status = (int)VentureStatusEnum.Open, StartingInvestment = 40.0, UserId = 3, ListingId = 1}
                );*/
        }
    }
}
