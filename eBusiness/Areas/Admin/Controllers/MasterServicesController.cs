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
    public class MasterServicesController : Controller
    {
        public IRepository<MasterServices> MasterServices { get; }

        public UserManager<AppUser> UserManager { get; }

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterServicesController(IRepository<MasterServices> _masterServices, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterServices = _masterServices;
            UserManager = _userManager;
            Hosting = _hosting;
        }

        public ActionResult Index()
        {
            var data = MasterServices.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterServices.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterServices.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterServicesViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterServicesDetailsFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterServices");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterServicesDetailsFile.FileName);
                    ImageName = "MasterServicesDetailsImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterServicesDetailsFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var data = new MasterServices
                {
                    MasterServicesId = collection.MasterServicesId,
                    MasterServicesIcon = collection.MasterServicesIcon,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesDescription = collection.MasterServicesDescription,
                    MasterServicesUrl = collection.MasterServicesUrl,
                    MasterServicesDetailsList = collection.MasterServicesDetailsList,
                    MasterServicesDetailsIconPhone = collection.MasterServicesDetailsIconPhone,
                    MasterServicesDetailsPhone = collection.MasterServicesDetailsPhone,
                    MasterServicesDetailsIconEmail = collection.MasterServicesDetailsIconEmail,
                    MasterServicesDetailsEmail = collection.MasterServicesDetailsEmail,
                    MasterServicesDetailsTitle = collection.MasterServicesDetailsTitle,
                    MasterServicesDetailsBreef = collection.MasterServicesDetailsBreef,
                    MasterServicesDetailsListDescription = collection.MasterServicesDetailsListDescription,
                    MasterServicesDetailsFullDescription = collection.MasterServicesDetailsFullDescription,
                    MasterServicesDetailsImageUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterServices.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterServices.Find(id);
            MasterServicesViewModel servicesmodel = new MasterServicesViewModel();
            servicesmodel.MasterServicesId = data.MasterServicesId;
            servicesmodel.MasterServicesIcon = data.MasterServicesIcon;
            servicesmodel.MasterServicesTitle = data.MasterServicesTitle;
            servicesmodel.MasterServicesDescription = data.MasterServicesDescription;
            servicesmodel.MasterServicesUrl = data.MasterServicesUrl;
            servicesmodel.MasterServicesDetailsList = data.MasterServicesDetailsList;
            servicesmodel.MasterServicesDetailsIconPhone = data.MasterServicesDetailsIconPhone;
            servicesmodel.MasterServicesDetailsPhone = data.MasterServicesDetailsPhone;
            servicesmodel.MasterServicesDetailsIconEmail = data.MasterServicesDetailsIconEmail;
            servicesmodel.MasterServicesDetailsEmail = data.MasterServicesDetailsEmail;
            servicesmodel.MasterServicesDetailsTitle = data.MasterServicesDetailsTitle;
            servicesmodel.MasterServicesDetailsBreef = data.MasterServicesDetailsBreef;
            servicesmodel.MasterServicesDetailsListDescription = data.MasterServicesDetailsListDescription;
            servicesmodel.MasterServicesDetailsFullDescription = data.MasterServicesDetailsFullDescription;
            servicesmodel.MasterServicesDetailsImageUrl = data.MasterServicesDetailsImageUrl;
            servicesmodel.CreateUser = data.CreateUser;
            servicesmodel.CreateDate = data.CreateDate;
            return View(servicesmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterServicesViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterServicesDetailsFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterServices");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterServicesDetailsFile.FileName);
                    ImageName = "MasterServicesDetailsImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterServicesDetailsFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var data = new MasterServices
                {
                    MasterServicesId = collection.MasterServicesId,
                    MasterServicesIcon = collection.MasterServicesIcon,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesDescription = collection.MasterServicesDescription,
                    MasterServicesUrl = collection.MasterServicesUrl,
                    MasterServicesDetailsList = collection.MasterServicesDetailsList,
                    MasterServicesDetailsIconPhone = collection.MasterServicesDetailsIconPhone,
                    MasterServicesDetailsPhone = collection.MasterServicesDetailsPhone,
                    MasterServicesDetailsIconEmail = collection.MasterServicesDetailsIconEmail,
                    MasterServicesDetailsEmail = collection.MasterServicesDetailsEmail,
                    MasterServicesDetailsTitle = collection.MasterServicesDetailsTitle,
                    MasterServicesDetailsBreef = collection.MasterServicesDetailsBreef,
                    MasterServicesDetailsListDescription = collection.MasterServicesDetailsListDescription,
                    MasterServicesDetailsFullDescription = collection.MasterServicesDetailsFullDescription,
                    MasterServicesDetailsImageUrl = (ImageName != "") ? ImageName : collection.MasterServicesDetailsImageUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterServices.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterServices.Delete(Delete, new Models.MasterServices { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
