using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HousingHack.Handler.Entity;

namespace HousingHack.Handler.Handlers
{
    public class VentureHandler
    {
        private HousingHackDb _db;

        public VentureHandler()
        {
            _db = new HousingHackDb();
        }
        public int AddVenture(Venture venture)
        {
            _db.Ventures.Add(venture);
            _db.SaveChanges();
            var query = from r in _db.Ventures
                        orderby r.Id descending
                        select r;
            if (query.Any())
            {
                return query.First().Id;
            }
            return 0;
        }

        public Venture RetrieveVenture(int ventureId)
        {
            var query = from r in _db.Ventures
                        where r.Id == ventureId
                        select r;
            if (query.Any())
            {
                return query.First();
            }
            return null;
        }

        public void UpdateVenture(Venture venture)
        {
            _db.Ventures.AddOrUpdate(venture);
            _db.SaveChanges();
        }

        public void DeleteListing(Venture venture)
        {
            _db.Ventures.Remove(venture);
            _db.SaveChanges();
        }

        public List<Venture> RetrieveAllVentures(int id = 1)
        {
            var query = from r in _db.Ventures
                        orderby r.Id descending 
                        select r;
            if (query.Any())
            {
                List<Venture> elements = query.ToList();
                return elements;
            }
            return null;
        }

        public List<Venture> RetrieveVenturesForAUser(int userId = 1)
        {
            var query = from r in _db.Ventures
                        where r.UserId == userId
                        orderby r.Id descending
                        select r;
            if (query.Any())
            {
                List<Venture> elements = query.ToList();
                return elements;
            }
            return null;
        }

        public List<Venture> RetrieveVenturesForAListing(int listingId = 1)
        {
            var query = from r in _db.Ventures
                        where r.ListingId == listingId
                        orderby r.Id descending
                        select r;
            if (query.Any())
            {
                List<Venture> elements = query.ToList();
                return elements;
            }
            return null;
        }
    }
}
