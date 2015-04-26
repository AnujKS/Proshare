using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingHack.Handler.Entity
{
    public class Listing
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string EstimatedCost { get; set; }
        public string PropertyType { get; set; }
        public string PropertyDescription { get; set; }
        public string Locality { get; set; }
        public string AvailabilityType { get; set; }
        public string PhotoLinks { get; set; }
        public int UserId { get; set; }
        public virtual List<Venture> Ventures { get; set; }
        //public int Id { get; set; }
        //public int Id { get; set; }
        //public int Id { get; set; }
        //public int Id { get; set; }
    }
}
