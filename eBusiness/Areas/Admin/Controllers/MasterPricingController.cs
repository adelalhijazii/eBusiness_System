using eBusiness.Areas.Admin.ViewModels;
using eBusiness.Models;
using eBusiness.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eBusiness.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterPricingController : Controller
    {
        public IRepository<MasterPricing> MasterPricing { get; }

        public UserManager<AppUser> UserManager { get; }

        public MasterPricingController(IRepository<MasterPricing> _masterPricing, UserManager<AppUser> _userManager)
        {
            MasterPricing = _masterPricing;
            UserManager = _userManager;
        }

        public ActionResult Index()
        {
            var data = MasterPricing.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterPricing.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterPricing.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterPricingViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterPricing
                {
                    MasterPricingId = collection.MasterPricingId,
                    MasterPricingTitle = collection.MasterPricingTitle,
                    MasterPricingBreef = collection.MasterPricingBreef,
                    MasterPricingDescription = collection.MasterPricingDescription,
                    MasterPricingUrl = collection.MasterPricingUrl,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterPricing.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterPricing.Find(id);
            MasterPricingViewModel pricingmodel = new MasterPricingViewModel();
            pricingmodel.MasterPricingId = data.MasterPricingId;
            pricingmodel.MasterPricingTitle = data.MasterPricingTitle;
            pricingmodel.MasterPricingBreef = data.MasterPricingBreef;
            pricingmodel.MasterPricingDescription = data.MasterPricingDescription;
            pricingmodel.MasterPricingUrl = data.MasterPricingUrl;
            pricingmodel.CreateUser = data.CreateUser;
            pricingmodel.CreateDate = data.CreateDate;
            return View(pricingmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterPricingViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterPricing
                {
                    MasterPricingId = collection.MasterPricingId,
                    MasterPricingTitle = collection.MasterPricingTitle,
                    MasterPricingBreef = collection.MasterPricingBreef,
                    MasterPricingDescription = collection.MasterPricingDescription,
                    MasterPricingUrl = collection.MasterPricingUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterPricing.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterPricing.Delete(Delete, new Models.MasterPricing { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
