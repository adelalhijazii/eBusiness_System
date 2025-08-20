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
    public class MasterServiceController : Controller
    {
        public IRepository<MasterService> MasterService { get; }

        public UserManager<AppUser> UserManager { get; }

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterServiceController(IRepository<MasterService> _masterService, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterService = _masterService;
            UserManager = _userManager;
            Hosting = _hosting;
        }

        public ActionResult Index()
        {
            var data = MasterService.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterService.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterService.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterServiceViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterServiceFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterService");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterServiceFile.FileName);
                    ImageName = "MasterServiceImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterServiceFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                MasterService obj = new MasterService
                {
                    MasterServiceId = collection.MasterServiceId,
                    MasterServiceIcon = collection.MasterServiceIcon,
                    MasterServiceTitle = collection.MasterServiceTitle,
                    MasterServiceDescription = collection.MasterServiceDescription,
                    MasterServiceImageUrl = ImageName,
                    MasterServiceUrl = collection.MasterServiceUrl,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterService.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterService.Find(id);
            MasterServiceViewModel servicemodel = new MasterServiceViewModel();
            servicemodel.MasterServiceId = data.MasterServiceId;
            servicemodel.MasterServiceIcon = data.MasterServiceIcon;
            servicemodel.MasterServiceTitle = data.MasterServiceTitle;
            servicemodel.MasterServiceDescription = data.MasterServiceDescription;
            servicemodel.MasterServiceImageUrl = data.MasterServiceImageUrl;
            servicemodel.MasterServiceUrl = data.MasterServiceUrl;
            servicemodel.CreateUser = data.CreateUser;
            servicemodel.CreateDate = data.CreateDate;
            return View(servicemodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterServiceViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterServiceFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterService");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterServiceFile.FileName);
                    ImageName = "MasterServiceImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterServiceFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new MasterService
                {
                    MasterServiceId = collection.MasterServiceId,
                    MasterServiceIcon = collection.MasterServiceIcon,
                    MasterServiceTitle = collection.MasterServiceTitle,
                    MasterServiceDescription = collection.MasterServiceDescription,
                    MasterServiceImageUrl = (ImageName != "") ? ImageName : collection.MasterServiceImageUrl,
                    MasterServiceUrl = collection.MasterServiceUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterService.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterService.Delete(Delete, new Models.MasterService { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
