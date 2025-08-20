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
    public class MasterAdvancedCapabilitiesController : Controller
    {
        public IRepository<MasterAdvancedCapabilities> MasterAdvancedCapabilities { get; }

        public UserManager<AppUser> UserManager { get; }

        public MasterAdvancedCapabilitiesController(IRepository<MasterAdvancedCapabilities> _masterAdvancedCapabilities, UserManager<AppUser> _userManager)
        {
            MasterAdvancedCapabilities = _masterAdvancedCapabilities;
            UserManager = _userManager;
        }

        public ActionResult Index()
        {
            var data = MasterAdvancedCapabilities.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterAdvancedCapabilities.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterAdvancedCapabilities.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterAdvancedCapabilitiesViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterAdvancedCapabilities
                {
                    MasterAdvancedCapabilitiesId = collection.MasterAdvancedCapabilitiesId,
                    MasterAdvancedCapabilitiesTitle = collection.MasterAdvancedCapabilitiesTitle,
                    MasterAdvancedCapabilitiesBreef = collection.MasterAdvancedCapabilitiesBreef,
                    MasterAdvancedCapabilitiesDescription = collection.MasterAdvancedCapabilitiesDescription,
                    MasterAdvancedCapabilitiesIcon = collection.MasterAdvancedCapabilitiesIcon,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterAdvancedCapabilities.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterAdvancedCapabilities.Find(id);
            MasterAdvancedCapabilitiesViewModel advancedcapabilitiesmodel = new MasterAdvancedCapabilitiesViewModel();
            advancedcapabilitiesmodel.MasterAdvancedCapabilitiesId = data.MasterAdvancedCapabilitiesId;
            advancedcapabilitiesmodel.MasterAdvancedCapabilitiesTitle = data.MasterAdvancedCapabilitiesTitle;
            advancedcapabilitiesmodel.MasterAdvancedCapabilitiesBreef = data.MasterAdvancedCapabilitiesBreef;
            advancedcapabilitiesmodel.MasterAdvancedCapabilitiesDescription = data.MasterAdvancedCapabilitiesDescription;
            advancedcapabilitiesmodel.MasterAdvancedCapabilitiesIcon = data.MasterAdvancedCapabilitiesIcon;
            advancedcapabilitiesmodel.CreateUser = data.CreateUser;
            advancedcapabilitiesmodel.CreateDate = data.CreateDate;
            return View(advancedcapabilitiesmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterAdvancedCapabilitiesViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterAdvancedCapabilities
                {
                    MasterAdvancedCapabilitiesId = collection.MasterAdvancedCapabilitiesId,
                    MasterAdvancedCapabilitiesTitle = collection.MasterAdvancedCapabilitiesTitle,
                    MasterAdvancedCapabilitiesBreef = collection.MasterAdvancedCapabilitiesBreef,
                    MasterAdvancedCapabilitiesDescription = collection.MasterAdvancedCapabilitiesDescription,
                    MasterAdvancedCapabilitiesIcon= collection.MasterAdvancedCapabilitiesIcon,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterAdvancedCapabilities.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterAdvancedCapabilities.Delete(Delete, new Models.MasterAdvancedCapabilities{ EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
