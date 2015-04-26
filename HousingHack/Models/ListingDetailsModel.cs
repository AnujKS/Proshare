using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingHack.Models
{
    public class ListingDetailsModel
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string EstimatedCost { get; set; }
        public string PropertyType { get; set; }
        public string PropertyDescription { get; set; }
        public string Locality { get; set; }
        public string AvailabilityType { get; set; }
        public string PhotoLinks { get; set; }
        public string ListedBy { get; set; }
        public string ContactNumber { get; set; }
    }
}