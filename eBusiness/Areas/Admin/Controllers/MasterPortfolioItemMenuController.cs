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
    public class MasterPortfolioItemMenuController : Controller
    {
        public UserManager<AppUser> UserManager;

        public IRepository<MasterPortfolioItemMenu> MasterPortfolioItemMenu { get; }

        public IRepository<MasterPortfolioCategoryMenu> MasterPortfolioCategoryMenu { get; }
        
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterPortfolioItemMenuController(IRepository<MasterPortfolioItemMenu> _masterPortfolioItemMenu, IRepository<MasterPortfolioCategoryMenu> _masterPortfolioCategoryMenu, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting, UserManager<AppUser> _userManager)
        {
            MasterPortfolioItemMenu = _masterPortfolioItemMenu;
            MasterPortfolioCategoryMenu = _masterPortfolioCategoryMenu;
            Hosting = _hosting;
            UserManager = _userManager;
        }
        
        public ActionResult Index()
        {
            var data = MasterPortfolioItemMenu.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterPortfolioItemMenu.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterPortfolioItemMenu.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            var data = MasterPortfolioCategoryMenu.View();
            ViewBag.category = data;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterPortfolioItemMenuViewmodel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Error Data Entry..!");
                    return View();
                }
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = UploadFile(collection.MasterPortfolioItemMenuFile);
                string PictureName = UploadFile(collection.MasterPortfolioItemMenuDetailsFile);

                var data = new MasterPortfolioItemMenu
                {
                    MasterPortfolioItemMenuId = collection.MasterPortfolioItemMenuId,
                    MasterPortfolioCategoryMenuId = collection.MasterPortfolioCategoryMenuId,
                    MasterPortfolioItemMenuTitle = collection.MasterPortfolioItemMenuTitle,
                    MasterPortfolioItemMenuBreef = collection.MasterPortfolioItemMenuBreef,
                    MasterPortfolioItemMenuImageUrl = ImageName,
                    MasterPortfolioItemMenuDetailsImageUrl = PictureName,
                    MasterPortfolioItemMenuDetailsTitle = collection.MasterPortfolioItemMenuDetailsTitle,
                    MasterPortfolioItemMenuDetailsDescription1 = collection.MasterPortfolioItemMenuDetailsDescription1,
                    MasterPortfolioItemMenuDetailsDescription2 = collection.MasterPortfolioItemMenuDetailsDescription2,
                    MasterPortfolioItemMenuDetailsQuote = collection.MasterPortfolioItemMenuDetailsQuote,
                    MasterPortfolioItemMenuDetailsName = collection.MasterPortfolioItemMenuDetailsName,
                    MasterPortfolioItemMenuDetailsPosition = collection.MasterPortfolioItemMenuDetailsPosition,
                    MasterPortfolioItemMenuDetailsProjectCategory = collection.MasterPortfolioItemMenuDetailsProjectCategory,
                    MasterPortfolioItemMenuDetailsProjectClient = collection.MasterPortfolioItemMenuDetailsProjectClient,
                    MasterPortfolioItemMenuDetailsProjectDate = collection.MasterPortfolioItemMenuDetailsProjectDate,
                    MasterPortfolioItemMenuDetailsProjectUrl = collection.MasterPortfolioItemMenuDetailsProjectUrl,
                    MasterPortfolioItemMenuDetailsProjectWebsite = collection.MasterPortfolioItemMenuDetailsProjectWebsite,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterPortfolioItemMenu.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterPortfolioItemMenu.Find(id);
            var data2 = MasterPortfolioCategoryMenu.View();
            ViewBag.category = data2;
            MasterPortfolioItemMenuViewmodel masterPortfolioItemMenuViewModel = new MasterPortfolioItemMenuViewmodel();
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuId = data.MasterPortfolioItemMenuId;
            masterPortfolioItemMenuViewModel.MasterPortfolioCategoryMenuId = data.MasterPortfolioCategoryMenuId;
            masterPortfolioItemMenuViewModel.MasterPortfolioCategoryMenu = MasterPortfolioCategoryMenu.Find(data.MasterPortfolioCategoryMenuId);
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuTitle = data.MasterPortfolioItemMenuTitle;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuBreef = data.MasterPortfolioItemMenuBreef;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuImageUrl = data.MasterPortfolioItemMenuImageUrl;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuDetailsImageUrl = data.MasterPortfolioItemMenuDetailsImageUrl;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuDetailsTitle = data.MasterPortfolioItemMenuDetailsTitle;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuDetailsDescription1 = data.MasterPortfolioItemMenuDetailsDescription1;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuDetailsDescription2 = data.MasterPortfolioItemMenuDetailsDescription2;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuDetailsQuote = data.MasterPortfolioItemMenuDetailsQuote;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuDetailsName = data.MasterPortfolioItemMenuDetailsName;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuDetailsPosition = data.MasterPortfolioItemMenuDetailsPosition;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuDetailsProjectCategory = data.MasterPortfolioItemMenuDetailsProjectCategory;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuDetailsProjectClient = data.MasterPortfolioItemMenuDetailsProjectClient;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuDetailsProjectDate = data.MasterPortfolioItemMenuDetailsProjectDate;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuDetailsProjectUrl = data.MasterPortfolioItemMenuDetailsProjectUrl;
            masterPortfolioItemMenuViewModel.MasterPortfolioItemMenuDetailsProjectWebsite = data.MasterPortfolioItemMenuDetailsProjectWebsite;
            masterPortfolioItemMenuViewModel.CreateUser = data.CreateUser;
            masterPortfolioItemMenuViewModel.CreateDate = data.CreateDate;
            return View(masterPortfolioItemMenuViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterPortfolioItemMenuViewmodel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = UploadFile(collection.MasterPortfolioItemMenuFile);
                string PictureName = UploadFile(collection.MasterPortfolioItemMenuDetailsFile);

                var data = new MasterPortfolioItemMenu
                {
                    MasterPortfolioItemMenuId = collection.MasterPortfolioItemMenuId,
                    MasterPortfolioCategoryMenuId = collection.MasterPortfolioCategoryMenuId,
                    MasterPortfolioItemMenuTitle = collection.MasterPortfolioItemMenuTitle,
                    MasterPortfolioItemMenuBreef = collection.MasterPortfolioItemMenuBreef,
                    MasterPortfolioItemMenuImageUrl = (ImageName != "") ? ImageName : collection.MasterPortfolioItemMenuImageUrl,
                    MasterPortfolioItemMenuDetailsImageUrl = (PictureName != "") ? PictureName : collection.MasterPortfolioItemMenuDetailsImageUrl,
                    MasterPortfolioItemMenuDetailsTitle = collection.MasterPortfolioItemMenuDetailsTitle,
                    MasterPortfolioItemMenuDetailsDescription1 = collection.MasterPortfolioItemMenuDetailsDescription1,
                    MasterPortfolioItemMenuDetailsDescription2 = collection.MasterPortfolioItemMenuDetailsDescription2,
                    MasterPortfolioItemMenuDetailsQuote = collection.MasterPortfolioItemMenuDetailsQuote,
                    MasterPortfolioItemMenuDetailsName = collection.MasterPortfolioItemMenuDetailsName,
                    MasterPortfolioItemMenuDetailsPosition = collection.MasterPortfolioItemMenuDetailsPosition,
                    MasterPortfolioItemMenuDetailsProjectCategory = collection.MasterPortfolioItemMenuDetailsProjectCategory,
                    MasterPortfolioItemMenuDetailsProjectClient = collection.MasterPortfolioItemMenuDetailsProjectClient,
                    MasterPortfolioItemMenuDetailsProjectDate = collection.MasterPortfolioItemMenuDetailsProjectDate,
                    MasterPortfolioItemMenuDetailsProjectUrl = collection.MasterPortfolioItemMenuDetailsProjectUrl,
                    MasterPortfolioItemMenuDetailsProjectWebsite = collection.MasterPortfolioItemMenuDetailsProjectWebsite,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true

                };
                MasterPortfolioItemMenu.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterPortfolioItemMenu.Delete(Delete, new Models.MasterPortfolioItemMenu { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }

        string UploadFile(IFormFile File)
        {
            string fileName = "";
            if (File != null)
            {
                string pathFile = Path.Combine(Hosting.WebRootPath, "Pictures/MasterPortfolioItemMenu");
                if (!Directory.Exists(pathFile))
                {
                    Directory.CreateDirectory(pathFile);
                }
                FileInfo fileInfo = new FileInfo(File.FileName);
                fileName = "Image_" + Guid.NewGuid() + fileInfo.Extension;
                string fullPath = Path.Combine(pathFile, fileName);
                File.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            return fileName;
        }
    }
}
