using eBusiness.Areas.Admin.Controllers;
using eBusiness.Models;
using eBusiness.Models.Repository;
using eBusiness.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Diagnostics;

namespace eBusiness.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IRepository<MasterAboutUs> _masterAboutUs, IRepository<MasterContactUsInformation> _masterContactUsInformation,
            IRepository<MasterPartner> _masterPartner, IRepository<MasterFeature> _masterFeature, IRepository<MasterFeatures> _masterFeatures,
            IRepository<MasterService> _masterService, IRepository<MasterServices> _masterServices, IRepository<MasterTeam> _masterTeam,
            IRepository<MasterAdvancedCapabilities> _masterAdvancedCapabilities, IRepository<MasterQuestions> _masterQuestions,
            IRepository<MasterPortfolioCategoryMenu> _masterPortfolioCategoryMenu, IRepository<MasterPortfolioItemMenu> _masterPortfolioItemMenu,
            IRepository<MasterMenu> _masterMenu, IRepository<MasterOurServices> _masterOurServices, IRepository<MasterPricing> _masterPricing,
            IRepository<MasterSocialMedium> _masterSocialMedium, IRepository<MasterUsefullLinks> _masterUsefullLinks, IRepository<MasterFocus> _masterFocus,
            IRepository<MasterWhyUs> _masterWhyUs,  IRepository<MasterTransformingData> _masterTransformingData, IRepository<SystemSetting> _systemSetting,
            IRepository<TransactionContactUs> _transactionContactUs, IRepository<TransactionNewsLetter> _transactionNewsLetter)
        {
            MasterAboutUs = _masterAboutUs;
            MasterContactUsInformation = _masterContactUsInformation;
            MasterFocus = _masterFocus;
            MasterPartner = _masterPartner;
            MasterFeature = _masterFeature;
            MasterFeatures = _masterFeatures;
            MasterService = _masterService;
            MasterServices = _masterServices;
            MasterAdvancedCapabilities = _masterAdvancedCapabilities;
            MasterPortfolioCategoryMenu = _masterPortfolioCategoryMenu;
            MasterPortfolioItemMenu = _masterPortfolioItemMenu;
            MasterQuestions = _masterQuestions;
            MasterTeam = _masterTeam;
            MasterMenu = _masterMenu;
            MasterOurServices = _masterOurServices;
            MasterPricing = _masterPricing;
            MasterSocialMedium = _masterSocialMedium;
            MasterUsefullLinks = _masterUsefullLinks;
            MasterWhyUs = _masterWhyUs;
            MasterTransformingData = _masterTransformingData;
            SystemSetting = _systemSetting;
            TransactionContactUs = _transactionContactUs;
            TransactionNewsLetter = _transactionNewsLetter;
        }

        public IRepository<MasterAboutUs> MasterAboutUs { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public IRepository<MasterFocus> MasterFocus { get; }
        public IRepository<MasterPartner> MasterPartner { get; }
        public IRepository<MasterFeature> MasterFeature { get; }
        public IRepository<MasterFeatures> MasterFeatures { get; }
        public IRepository<MasterService> MasterService { get; }
        public IRepository<MasterServices> MasterServices { get; }
        public IRepository<MasterAdvancedCapabilities> MasterAdvancedCapabilities { get; }
        public IRepository<MasterPortfolioCategoryMenu> MasterPortfolioCategoryMenu { get; }
        public IRepository<MasterPortfolioItemMenu> MasterPortfolioItemMenu { get; }
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<MasterQuestions> MasterQuestions { get; }
        public IRepository<MasterTeam> MasterTeam { get; }
        public IRepository<MasterOurServices> MasterOurServices { get; }
        public IRepository<MasterPricing> MasterPricing { get; }
        public IRepository<MasterSocialMedium> MasterSocialMedium { get; }
        public IRepository<MasterUsefullLinks> MasterUsefullLinks { get; }
        public IRepository<MasterWhyUs> MasterWhyUs { get; }
        public IRepository<MasterTransformingData> MasterTransformingData { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<TransactionContactUs> TransactionContactUs { get; }
        public IRepository<TransactionNewsLetter> TransactionNewsLetter { get; }

        public IActionResult Index()
        {
            HomeViewModel obj = new HomeViewModel();

            obj.ListMenu = MasterMenu.ViewFromClient().ToList();
            obj.ListPartner = MasterPartner.ViewFromClient().ToList();
            obj.TransformingData = MasterTransformingData.Find(1);

            obj.ListService = MasterService.ViewFromClient().ToList();
            obj.ListServices = MasterServices.ViewFromClient().ToList();
            obj.Feature = MasterFeature.Find(1);
            obj.ListFeatures = MasterFeatures.ViewFromClient().ToList();
            obj.ListAdvancedCapabilities = MasterAdvancedCapabilities.ViewFromClient().ToList();

            obj.ListWhyUs = MasterWhyUs.ViewFromClient().ToList();
            obj.Focus = MasterFocus.Find(1);

            obj.ListPortfolioCategoryMenu = MasterPortfolioCategoryMenu.ViewFromClient().ToList();
            obj.ListPortfolioItemMenu = MasterPortfolioItemMenu.ViewFromClient().ToList();
            obj.ListPricing = MasterPricing.ViewFromClient().ToList();
            obj.ListQuestions = MasterQuestions.ViewFromClient().ToList();
            obj.ListTeam = MasterTeam.ViewFromClient().ToList();

            obj.ContactUsInformation1 = MasterContactUsInformation.Find(1);
            obj.ContactUsInformation2 = MasterContactUsInformation.Find(2);
            obj.ContactUsInformation3 = MasterContactUsInformation.Find(3);

            obj.AboutUs = MasterAboutUs.Find(1);
            obj.ListUsefullLinks = MasterUsefullLinks.ViewFromClient().ToList();
            obj.ListOurServices = MasterOurServices.ViewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.ViewFromClient().ToList();

            obj.Setting = SystemSetting.Find(1);
            return View(obj);
        }

        public IActionResult PortfolioDetails(int idDetails)
        {
            HomeViewModel obj = new HomeViewModel();
            obj.PortfolioItemMenu = MasterPortfolioItemMenu.Find(idDetails);

            obj.ListMenu = MasterMenu.ViewFromClient().ToList();
            obj.AboutUs = MasterAboutUs.Find(1);
            obj.ListUsefullLinks = MasterUsefullLinks.ViewFromClient().ToList();
            obj.ListOurServices = MasterOurServices.ViewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.ViewFromClient().ToList();

            obj.Setting = SystemSetting.Find(1);
            return View(obj);
        }

        public IActionResult ServiceDetails(int idDetails)
        {
            HomeViewModel obj = new HomeViewModel();
            obj.Services = MasterServices.Find(idDetails);

            obj.ListMenu = MasterMenu.ViewFromClient().ToList();
            obj.AboutUs = MasterAboutUs.Find(1);
            obj.ListUsefullLinks = MasterUsefullLinks.ViewFromClient().ToList();
            obj.ListOurServices = MasterOurServices.ViewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.ViewFromClient().ToList();

            obj.Setting = SystemSetting.Find(1);
            return View(obj);
        }

        [HttpPost]
        public IActionResult ContactUs(HomeViewModel data)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "Failed";
                return RedirectToAction("ContactUs", "Home");
            }

            TransactionContactUs.Add(data.ContactUs);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult NewsLetter(HomeViewModel data)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "Failed";
                return RedirectToAction("NewsLetter", "Home");
            }

            TransactionNewsLetter.Add(data.NewsLetter);
            return RedirectToAction("Index", "Home");
        }
    }
}
