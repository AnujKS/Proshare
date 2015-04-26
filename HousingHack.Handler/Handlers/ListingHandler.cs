using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HousingHack.Handler.Entity;

namespace HousingHack.Handler.Handlers
{
    public class ListingHandler
    {
        private HousingHackDb _db;

        public ListingHandler()
        {
            _db = new HousingHackDb();
        }

        public int AddListing(Listing listing)
        {
            _db.Listings.Add(listing);
            _db.SaveChanges();
            var query = from r in _db.Listings
                        orderby r.Id descending
                        select r;
            if (query.Any())
            {
                return query.First().Id;
            }
            return 0;
        }

        public Listing RetrieveListing(int listingId)
        {
            var query = from r in _db.Listings
                        where r.Id == listingId
                        select r;
            if (query.Any())
            {
                return query.First();
            }
            return null;
        }

        public void UpdateListing(Listing listing)
        {
            _db.Listings.AddOrUpdate(listing);
            _db.SaveChanges();
        }

        public void DeleteListing(Listing listing)
        {
            if (listing!=null)
            {
                _db.Listings.Remove(listing);
                _db.SaveChanges();
            }
        }

        public List<Listing> RetrieveAllListings()
        {
            var query = from r in _db.Listings
                        orderby r.Id descending 
                        select r;
            if (query.Any())
            {
                List<Listing> elements = query.ToList();
                return elements;
            }
            return null;
        }

        public List<Listing> RetrieveListingsForAUser(int userId = 1)
        {
            var query = from r in _db.Listings
                        where r.UserId == userId
                        orderby r.Id descending
                        select r;
            if (query.Any())
            {
                List<Listing> elements = query.ToList();
                return elements;
            }
            return null;
        }
    }
}
