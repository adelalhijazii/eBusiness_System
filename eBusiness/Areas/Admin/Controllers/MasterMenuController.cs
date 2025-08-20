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
    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }

        public UserManager<AppUser> UserManager { get; }

        public MasterMenuController(IRepository<MasterMenu> _masterMenu, UserManager<AppUser> _userManager)
        {
            MasterMenu = _masterMenu;
            UserManager = _userManager;
        }

        public ActionResult Index()
        {
            var data = MasterMenu.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterMenu.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterMenu.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterMenuViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterMenu
                {
                    MasterMenuId = collection.MasterMenuId,
                    MasterMenuName = collection.MasterMenuName,
                    MasterMenuUrl = collection.MasterMenuUrl,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterMenu.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterMenu.Find(id);
            MasterMenuViewModel menumodel = new MasterMenuViewModel();
            menumodel.MasterMenuId = data.MasterMenuId;
            menumodel.MasterMenuName = data.MasterMenuName;
            menumodel.MasterMenuUrl = data.MasterMenuUrl;
            menumodel.CreateUser = data.CreateUser;
            menumodel.CreateDate = data.CreateDate;
            return View(menumodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterMenuViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterMenu
                {
                    MasterMenuId = collection.MasterMenuId,
                    MasterMenuName = collection.MasterMenuName,
                    MasterMenuUrl = collection.MasterMenuUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterMenu.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterMenu.Delete(Delete, new Models.MasterMenu { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
