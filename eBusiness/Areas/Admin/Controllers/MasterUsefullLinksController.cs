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
    public class MasterUsefullLinksController : Controller
    {
        public IRepository<MasterUsefullLinks> MasterUsefullLinks { get; }

        public UserManager<AppUser> UserManager { get; }

        public MasterUsefullLinksController(IRepository<MasterUsefullLinks> _masterUsefullLinks, UserManager<AppUser> _userManager)
        {
            MasterUsefullLinks = _masterUsefullLinks;
            UserManager = _userManager;
        }

        public ActionResult Index()
        {
            var data = MasterUsefullLinks.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterUsefullLinks.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterUsefullLinks.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterUsefullLinksViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterUsefullLinks
                {
                    MasterUsefullLinksId = collection.MasterUsefullLinksId,
                    MasterUsefullLinksName = collection.MasterUsefullLinksName,
                    MasterUsefullLinksUrl = collection.MasterUsefullLinksUrl,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterUsefullLinks.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterUsefullLinks.Find(id);
            MasterUsefullLinksViewModel usefullLinksmodel = new MasterUsefullLinksViewModel();
            usefullLinksmodel.MasterUsefullLinksId = data.MasterUsefullLinksId;
            usefullLinksmodel.MasterUsefullLinksName = data.MasterUsefullLinksName;
            usefullLinksmodel.MasterUsefullLinksUrl = data.MasterUsefullLinksUrl;
            usefullLinksmodel.CreateUser = data.CreateUser;
            usefullLinksmodel.CreateDate = data.CreateDate;
            return View(usefullLinksmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterUsefullLinksViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterUsefullLinks
                {
                    MasterUsefullLinksId = collection.MasterUsefullLinksId,
                    MasterUsefullLinksName = collection.MasterUsefullLinksName,
                    MasterUsefullLinksUrl = collection.MasterUsefullLinksUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterUsefullLinks.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterUsefullLinks.Delete(Delete, new Models.MasterUsefullLinks { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
