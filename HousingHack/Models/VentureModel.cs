using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HousingHack.Models
{
    public class VentureModel
    {
        public string Plans { get; set; }
        public IEnumerable<SelectListItem> VentureTypeList
        {
            get
            {
                return new[]
                {
                    new SelectListItem {Value = "Long Term", Text = "Long Term"},
                    new SelectListItem {Value = "Short Term", Text = "Short Term"}
                };
            }
        }
        public string VentureType { get; set; }
        public double TotalInvestment { get; set; }
        public double StartingInvestment { get; set; }
        public string Status { get; set; }
        public string ListingName { get; set; }
        public string ListingPrice { get; set; }
        public string InitiatedBy { get; set; }
        public int UserId { get; set; }
        public int ListingId { get; set; }
        public int Id { get; set; }

        public bool IsMyVenture { get; set; }
        public bool IsMyInvestment { get; set; }
    }
}