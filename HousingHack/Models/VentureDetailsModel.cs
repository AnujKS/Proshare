using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HousingHack.Models
{
    public class VentureDetailsModel
    {
        public VentureDetailsModel()
        {
            InvestmentModels = new List<VentureInvestmentDetailsModel>();
        }
        public string StartedBy { get; set; }
        public string ListingName { get; set; }
        public string ListingPrice { get; set; }
        public string Plans { get; set; }
        public string Status { get; set; }
        public double InitialInvestment { get; set; }
        public double TotalInvestment { get; set; }
        public List<VentureInvestmentDetailsModel> InvestmentModels { get; set; }
        public VentureInvestmentModel VentureInvestment { get; set; }
        public IEnumerable<SelectListItem> VentureStatusList
        {
            get
            {
                return new[]
                {
                    new SelectListItem {Value = "1", Text = "Open"},
                    new SelectListItem {Value = "2", Text = "Accepted"},
                    new SelectListItem {Value = "3", Text = "Rejected"},
                    new SelectListItem {Value = "4", Text = "Processing"}
                };
            }
        }
    }

    public class VentureInvestmentDetailsModel
    {
        public double InvestmentPercentage { get; set; }
        public string UserName { get; set; }
    }

    public class VentureInvestmentModel
    {
        public double InvestmentPercentage { get; set; }
        public int UserId{ get; set; }
        public int VentureId{ get; set; }
    }
}