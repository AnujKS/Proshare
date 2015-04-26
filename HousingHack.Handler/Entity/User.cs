using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingHack.Handler.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public virtual List<Listing> Listings { get; set; }
        public virtual List<Venture> Ventures { get; set; }
        public virtual List<VentureInvestment> VentureInvestments { get; set; }
        //public int Id { get; set; }
        //public int Id { get; set; }
        //public int Id { get; set; }
        //public int Id { get; set; }
    }
}
