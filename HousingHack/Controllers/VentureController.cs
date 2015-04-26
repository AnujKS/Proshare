using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HousingHack.Constants;
using HousingHack.Handler;
using HousingHack.Handler.Entity;
using HousingHack.Handler.Handlers;
using HousingHack.Models;

namespace HousingHack.Controllers
{
    public class VentureController : Controller
    {
        private VentureHandler _ventureHandler;
        private VentureInvestmentHandler _ventureInvestmentHandler;
        private UserHandler _userHandler;
        private ListingHandler _listingHandler;
        // GET venture

        public VentureController()
        {
            _ventureInvestmentHandler = new VentureInvestmentHandler();
            _ventureHandler=new VentureHandler();  
            _userHandler = new UserHandler();
            _listingHandler = new ListingHandler();
        }

        public ActionResult List(int listingId = 0)
        {
            var ventureList = new List<Venture>();
            var listingName = "";
            var listingPrice = "";
            if (listingId == 0)
            {
                ventureList = _ventureHandler.RetrieveAllVentures();
            }
            else
            {
                ventureList = _ventureHandler.RetrieveVenturesForAListing(listingId);
                var listing = _listingHandler.RetrieveListing(listingId);
                listingName = listing.PropertyName;
                listingPrice = listing.EstimatedCost;
            }
            if (ventureList != null && ventureList.Count != 0)
            {
                List<VentureModel> viewList = ventureList.Select(venture => new VentureModel()
                {
                    Plans = venture.Plans,
                    TotalInvestment = venture.TotalInvestment,
                    StartingInvestment = venture.StartingInvestment,
                    VentureType = venture.VentureType,
                    Status = ((VentureStatusEnum) venture.Status).ToString(),
                    Id = venture.Id,
                    ListingId = listingId,
                    ListingName =
                        listingId == 0 ? _listingHandler.RetrieveListing(venture.ListingId).PropertyName : listingName,
                    ListingPrice =
                        listingId == 0 ? _listingHandler.RetrieveListing(venture.ListingId).EstimatedCost : listingPrice,
                    InitiatedBy = _userHandler.RetrieveUser(venture.UserId).Name,
                    IsMyVenture = false,
                    IsMyInvestment = false
                }).ToList();
                return View(viewList);
            }
            else
            {
                var model = new NullHandlerModel()
                {
                    Title = "Venture",
                    listingId = listingId,
                    Message = "No Ventures Available."
                };
                return View("NullHandleView", model);
            }
        }

        public ActionResult Details(int ventureId)
        {
            var venture = _ventureHandler.RetrieveVenture(ventureId);
            var user = _userHandler.RetrieveUser(venture.UserId);
            var listing = _listingHandler.RetrieveListing(venture.ListingId);
            var ventureDetailsModel = new VentureDetailsModel()
            {
                StartedBy = user.Name,
                ListingName = listing.PropertyName,
                ListingPrice = listing.EstimatedCost,
                Plans = venture.Plans,
                InitialInvestment = venture.StartingInvestment,
                TotalInvestment = venture.TotalInvestment,
                Status = venture.Status.ToString(),
                VentureInvestment = new VentureInvestmentModel
                {
                    UserId = AppContants.LoggedInUser.Id,
                    VentureId = ventureId
                }
            };
            foreach (var investment in venture.VentureInvestments)
            {
                user = _userHandler.RetrieveUser(investment.UserId);
                ventureDetailsModel.InvestmentModels.Add(new VentureInvestmentDetailsModel
                {
                    InvestmentPercentage = investment.Investment,
                    UserName = user.Name
                });
            }
            return View(ventureDetailsModel);
        }

        public ActionResult AddInvestment(VentureDetailsModel model)
        {
            var ventureInvestment = new VentureInvestment()
            {
                Investment = model.VentureInvestment.InvestmentPercentage,
                UserId = model.VentureInvestment.UserId,
                VentureId = model.VentureInvestment.VentureId
            };
            _ventureInvestmentHandler.AddVentureInvestment(ventureInvestment);
            var venture = _ventureHandler.RetrieveVenture(ventureInvestment.VentureId);
            venture.TotalInvestment += ventureInvestment.Investment;
            _ventureHandler.UpdateVenture(venture);
            return RedirectToAction("Details", new{ventureId = model.VentureInvestment.VentureId});
        }

        public ActionResult ChangeStatus(VentureDetailsModel model)
        {
            var venture = _ventureHandler.RetrieveVenture(model.VentureInvestment.VentureId);
            venture.Status = int.Parse(model.Status);
            _ventureHandler.UpdateVenture(venture);
            return RedirectToAction("Details", new { ventureId = model.VentureInvestment.VentureId });
        }

        public ActionResult MyVentures(int userId)
        {
            var ventureList = _ventureHandler.RetrieveVenturesForAUser(userId);
            var userName = _userHandler.RetrieveUser(userId).Name;
            if (ventureList != null)
            {
            List<VentureModel> viewList = ventureList.Select(venture => new VentureModel()
            {
                Plans = venture.Plans,
                TotalInvestment = venture.TotalInvestment,
                StartingInvestment = venture.StartingInvestment,
                VentureType = venture.VentureType,
                    Status = ((VentureStatusEnum) venture.Status).ToString(),
                Id = venture.Id,
                ListingName = _listingHandler.RetrieveListing(venture.ListingId).PropertyName,
                ListingPrice = _listingHandler.RetrieveListing(venture.ListingId).EstimatedCost,
                InitiatedBy = userName,
                IsMyVenture = true
            }).ToList();
            return View("List", viewList);
        }
            else
            {
                var model = new NullHandlerModel()
                {
                    Title = "Your Ventures",
                    Message = "No Ventures Available"
                };
                return View("NullHandleView", model);
            }
        }

        public ActionResult MyInvestments(int userId)
        {
            var investments = _userHandler.RetrieveUser(userId).VentureInvestments;
            if (investments != null && investments.Count != 0)
            {
                var viewList =
                    investments.Select(investment => _ventureHandler.RetrieveVenture(investment.VentureId))
                        .Select(venture => new VentureModel()
                        {
                Plans = venture.Plans, 
                TotalInvestment = venture.TotalInvestment, 
                StartingInvestment = venture.StartingInvestment, 
                VentureType = venture.VentureType, 
                Status = ((VentureStatusEnum)venture.Status).ToString(),
                Id = venture.Id, 
                ListingName = _listingHandler.RetrieveListing(venture.ListingId).PropertyName, 
                ListingPrice = _listingHandler.RetrieveListing(venture.ListingId).EstimatedCost, 
                InitiatedBy = _userHandler.RetrieveUser(venture.UserId).Name,
                IsMyInvestment = true
            }).ToList();
            return View("List", viewList);
        }
            var model = new NullHandlerModel()
            {
                Title = "Investments",
                Message = "No Investments Available"
            };
            return View("NullHandleView", model);
        }

        [HttpGet]
        public ActionResult AddVentures(int ListingId = 1)
        {
            var venture = new VentureModel()
            {
                ListingId = ListingId
            };
            return View(venture);
        }

        [HttpPost]
        public ActionResult AddVentures(Venture model)
        {
            Venture venture = new Venture();
            venture.Plans = model.Plans;
            venture.StartingInvestment = model.StartingInvestment;
            venture.Status = 2;
            venture.TotalInvestment = model.TotalInvestment;
            venture.Status = 1;
            venture.TotalInvestment = model.StartingInvestment;
            venture.VentureType = model.VentureType;
            venture.UserId = AppContants.LoggedInUser.Id;
            venture.ListingId = model.ListingId;
            var id = _ventureHandler.AddVenture(venture);
            var ventureInvestment = new VentureInvestment()
            {
                Investment = model.StartingInvestment,
                UserId = venture.UserId,
                VentureId = id
            };
            _ventureInvestmentHandler.AddVentureInvestment(ventureInvestment);
            return RedirectToAction("List", new {listingId = model.ListingId});
        }


    }
}
