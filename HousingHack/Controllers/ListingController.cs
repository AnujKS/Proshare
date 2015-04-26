using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using HousingHack.Constants;
using HousingHack.Handler.Entity;
using HousingHack.Handler.Handlers;
using HousingHack.Models;

namespace HousingHack.Controllers
{
    public class ListingController : Controller
    {
        private ListingHandler _listingHandler;
        private VentureHandler _ventureHandler;
        private UserHandler _userHandler;
        public ListingController()
        {
            _ventureHandler = new VentureHandler();
            _listingHandler = new ListingHandler();
            _userHandler = new UserHandler();
        }
        //
        // GET: /Listing/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int userId = 0)
        {
            var listingsList = new List<Listing>();
            var userName = "";
            if (userId==0)
            {
                listingsList = _listingHandler.RetrieveAllListings();
            }
            else
            {
                listingsList = _listingHandler.RetrieveListingsForAUser(userId);
                userName = _userHandler.RetrieveUser(userId).Name;
            }
            List<ListingsModel> viewList = listingsList.Select(listing => new ListingsModel()
                {
                    Id = listing.Id,
                    AvailabilityType = listing.AvailabilityType,
                    EstimatedCost = listing.EstimatedCost,
                    PropertyName = listing.PropertyName,
                    PropertyType = listing.PropertyType,
                    Locality = listing.Locality,
                    PhotoLinks = listing.PhotoLinks,
                SellerName = userId == 0 ? _userHandler.RetrieveUser(listing.UserId).Name : userName
            }).ToList();
            
            return View(viewList);
        }

        public ActionResult DeleteListing(int userId, int listingId)
        {
            _listingHandler.DeleteListing(_listingHandler.RetrieveListing(listingId));
            return RedirectToAction("List", new {userId});
        }

        public ActionResult Dashboard(int userId)
        {
            var model = new DashboardModel()
            {
                TotalListings = _listingHandler.RetrieveAllListings().Count,
                TotalVentures = _ventureHandler.RetrieveAllVentures().Count
            };
            return View(model);
        }

        public ActionResult Details(int listingId)
        {
            var listing = _listingHandler.RetrieveListing(listingId);
            var user = _userHandler.RetrieveUser(listing.UserId);
            var listingModel = new ListingDetailsModel()
            {
                AvailabilityType = listing.AvailabilityType,
                EstimatedCost = listing.EstimatedCost,
                ListedBy = user.Name,
                Locality = listing.Locality,
                PhotoLinks = listing.PhotoLinks,
                PropertyDescription = listing.PropertyDescription,
                PropertyName = listing.PropertyName,
                PropertyType = listing.PropertyType,
                Id = listing.Id,
                ContactNumber = user.PhoneNumber
            };
            return View(listingModel);
        }

        [HttpGet]
        public ActionResult AddListing(int userId=0)
        {
            var listingmodel = new ListingsModel()
            {
                SellerName = AppContants.LoggedInUser.Name,
                UserId=userId
            };
            return View(listingmodel);
        }

        [HttpPost]
        public ActionResult AddListing(ListingsModel model)
        {
            Listing listing=new Listing();
            listing.PropertyName = model.PropertyName;
            listing.AvailabilityType = model.AvailabilityType;
            listing.Locality = model.Locality;
            listing.PhotoLinks = model.PhotoLinks;
            listing.EstimatedCost = model.EstimatedCost;
            listing.UserId = AppContants.LoggedInUser.Id;
            listing.PropertyType = model.PropertyType;
            listing.PropertyDescription = model.PropertyDescription;
            _listingHandler.AddListing(listing);
            return RedirectToAction("List", 0);
        }
    }
}
