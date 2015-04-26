using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;

namespace HousingHack.Models
{
    public class ListingsModel
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string EstimatedCost { get; set; }
        public string PropertyType { get; set; }
        public IEnumerable<SelectListItem> PropertyTypeList
        {
            get
            {
                return new[]
                {
                    new SelectListItem {Value = "Land", Text = "Land"},
                    new SelectListItem {Value = "Apartment", Text = "House/Apartment"}
                };
            }
        }
        public string Locality { get; set; }
        public string AvailabilityType { get; set; }
        public IEnumerable<SelectListItem> AvailabilityTypeList
        {
            get
            {
                return new[]
                {
                    new SelectListItem {Value = "Buy", Text = "Buy"},
                    new SelectListItem {Value = "Rent", Text = "Rent"},
                     new SelectListItem {Value = "Lease", Text = "Lease"},
                };
            }
        }
        public string PhotoLinks { get; set; }
        public int UserId { get; set; }
        public string SellerName { get; set; }
        public string PropertyDescription { get; set; }
        }
    }
