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
    public class MasterPortfolioCategoryMenuController : Controller
    {
        public IRepository<MasterPortfolioCategoryMenu> MasterPortfolioCategoryMenu { get; }

        public UserManager<AppUser> UserManager { get; }

        public MasterPortfolioCategoryMenuController(IRepository<MasterPortfolioCategoryMenu> _masterPortfolioCategoryMenu, UserManager<AppUser> _userManager)
        {
            MasterPortfolioCategoryMenu = _masterPortfolioCategoryMenu;
            UserManager = _userManager;
        }
        
        public ActionResult Index()
        {
            var data = MasterPortfolioCategoryMenu.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterPortfolioCategoryMenu.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterPortfolioCategoryMenu.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterPortfolioCategoryMenuViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterPortfolioCategoryMenu
                {
                    MasterPortfolioCategoryMenuId = collection.MasterPortfolioCategoryMenuId,
                    MasterPortfolioCategoryMenuName = collection.MasterPortfolioCategoryMenuName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterPortfolioCategoryMenu.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterPortfolioCategoryMenu.Find(id);
            MasterPortfolioCategoryMenuViewModel masterCategoryMenuViewModel = new MasterPortfolioCategoryMenuViewModel();
            masterCategoryMenuViewModel.MasterPortfolioCategoryMenuId = data.MasterPortfolioCategoryMenuId;
            masterCategoryMenuViewModel.MasterPortfolioCategoryMenuName = data.MasterPortfolioCategoryMenuName;
            masterCategoryMenuViewModel.CreateUser = data.CreateUser;
            masterCategoryMenuViewModel.CreateDate = data.CreateDate;
            return View(masterCategoryMenuViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterPortfolioCategoryMenuViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterPortfolioCategoryMenu
                {
                    MasterPortfolioCategoryMenuId = collection.MasterPortfolioCategoryMenuId,
                    MasterPortfolioCategoryMenuName = collection.MasterPortfolioCategoryMenuName,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterPortfolioCategoryMenu.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterPortfolioCategoryMenu.Delete(Delete, new Models.MasterPortfolioCategoryMenu { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
