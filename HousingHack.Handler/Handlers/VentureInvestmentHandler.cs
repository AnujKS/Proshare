using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HousingHack.Handler.Entity;

namespace HousingHack.Handler.Handlers
{
    public class VentureInvestmentHandler
    {
        private HousingHackDb _db;

        public VentureInvestmentHandler()
        {
            _db = new HousingHackDb();
        }
        public int AddVentureInvestment(VentureInvestment ventureInvestment)
        {
            _db.VentureInvestments.Add(ventureInvestment);
            _db.SaveChanges();
            var query = from r in _db.VentureInvestments
                        orderby r.Id descending
                        select r;
            if (query.Any())
            {
                return query.First().Id;
            }
            return 0;
        }

        public void UpdateVenture(VentureInvestment ventureInvestment)
        {
            _db.VentureInvestments.AddOrUpdate(ventureInvestment);
            _db.SaveChanges();
        }

        public void DeleteListing(VentureInvestment ventureInvestment)
        {
            _db.VentureInvestments.Remove(ventureInvestment);
            _db.SaveChanges();
        }

        public List<VentureInvestment> RetrieveAllVentureInvestmentsForAVenture(int ventureId = 1)
        {
            var query = from r in _db.VentureInvestments
                        where r.VentureId == ventureId
                        select r;
            if (query.Any())
            {
                List<VentureInvestment> elements = query.ToList();
                return elements;
            }
            return null;
        }

        public List<VentureInvestment> RetrieveAllVentureInvestmentsForAUser(int userId = 1)
        {
            var query = from r in _db.VentureInvestments
                        where r.VentureId == userId
                        select r;
            if (query.Any())
            {
                List<VentureInvestment> elements = query.ToList();
                return elements;
            }
            return null;
        }
    }
}
