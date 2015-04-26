using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingHack.Handler.Entity
{
    public class Venture
    {
        public int Id { get; set; }
        public string Plans { get; set; }
        public string VentureType { get; set; }
        public double TotalInvestment { get; set; }
        public double StartingInvestment{ get; set; }
        public int Status{ get; set; }
        public int UserId { get; set; }
        public int ListingId { get; set; }
        public virtual List<VentureInvestment> VentureInvestments { get; set; }
        //public int Id { get; set; }
        //public int Id { get; set; }
        //public int Id { get; set; }
        //public int Id { get; set; }
    }
}
