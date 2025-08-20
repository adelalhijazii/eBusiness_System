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
    public class MasterFocusController : Controller
    {
        public IRepository<MasterFocus> MasterFocus { get; }

        public UserManager<AppUser> UserManager { get; }

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterFocusController(IRepository<MasterFocus> _masterFocus, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterFocus = _masterFocus;
            UserManager = _userManager;
            Hosting = _hosting;
        }

        public ActionResult Index()
        {
            var data = MasterFocus.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterFocus.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterFocus.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterFocusViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterFocusFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterFocus");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterFocusFile.FileName);
                    ImageName = "MasterFocusImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterFocusFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                MasterFocus obj = new MasterFocus
                {
                    MasterFocusId = collection.MasterFocusId,
                    MasterFocusTitle = collection.MasterFocusTitle,
                    MasterFocusBreef = collection.MasterFocusBreef,
                    MasterFocusPercentageRateIcon1 = collection.MasterFocusPercentageRateIcon1,
                    MasterFocusPercentageRate1 = collection.MasterFocusPercentageRate1,
                    MasterFocusPercentageRateIcon2 = collection.MasterFocusPercentageRateIcon2,
                    MasterFocusPercentageRate2 = collection.MasterFocusPercentageRate2,
                    MasterFocusDescription = collection.MasterFocusDescription,
                    MasterFocusImageUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterFocus.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterFocus.Find(id);
            MasterFocusViewModel focusmodel = new MasterFocusViewModel();
            focusmodel.MasterFocusId = data.MasterFocusId;
            focusmodel.MasterFocusTitle = data.MasterFocusTitle;
            focusmodel.MasterFocusBreef = data.MasterFocusBreef;
            focusmodel.MasterFocusPercentageRateIcon1 = data.MasterFocusPercentageRateIcon1;
            focusmodel.MasterFocusPercentageRate1 = data.MasterFocusPercentageRate1;
            focusmodel.MasterFocusPercentageRateIcon2 = data.MasterFocusPercentageRateIcon2;
            focusmodel.MasterFocusPercentageRate2 = data.MasterFocusPercentageRate2;
            focusmodel.MasterFocusDescription = data.MasterFocusDescription;
            focusmodel.MasterFocusImageUrl = data.MasterFocusImageUrl;
            focusmodel.CreateUser = data.CreateUser;
            focusmodel.CreateDate = data.CreateDate;
            return View(focusmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterFocusViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterFocusFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterFocus");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterFocusFile.FileName);
                    ImageName = "MasterFocusImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterFocusFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new MasterFocus
                {
                    MasterFocusId = collection.MasterFocusId,
                    MasterFocusTitle = collection.MasterFocusTitle,
                    MasterFocusBreef = collection.MasterFocusBreef,
                    MasterFocusPercentageRateIcon1 = collection.MasterFocusPercentageRateIcon1,
                    MasterFocusPercentageRate1 = collection.MasterFocusPercentageRate1,
                    MasterFocusPercentageRateIcon2 = collection.MasterFocusPercentageRateIcon2,
                    MasterFocusPercentageRate2 = collection.MasterFocusPercentageRate2,
                    MasterFocusDescription = collection.MasterFocusDescription,
                    MasterFocusImageUrl = (ImageName != "") ? ImageName : collection.MasterFocusImageUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterFocus.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterFocus.Delete(Delete, new Models.MasterFocus { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
