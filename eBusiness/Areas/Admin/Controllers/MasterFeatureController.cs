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
    public class MasterFeatureController : Controller
    {
        public IRepository<MasterFeature> MasterFeature { get; }

        public UserManager<AppUser> UserManager { get; }

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterFeatureController(IRepository<MasterFeature> _masterFeature, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterFeature = _masterFeature;
            UserManager = _userManager;
            Hosting = _hosting;
        }

        public ActionResult Index()
        {
            var data = MasterFeature.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterFeature.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterFeature.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterFeatureViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterFeatureFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterFeature");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterFeatureFile.FileName);
                    ImageName = "MasterFeatureImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterFeatureFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                MasterFeature obj = new MasterFeature
                {
                    MasterFeatureId = collection.MasterFeatureId,
                    MasterFeatureTitle = collection.MasterFeatureTitle,
                    MasterFeatureBreef = collection.MasterFeatureBreef,
                    MasterFeatureDescription = collection.MasterFeatureDescription,
                    MasterFeatureImageUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterFeature.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterFeature.Find(id);
            MasterFeatureViewModel featuremodel = new MasterFeatureViewModel();
            featuremodel.MasterFeatureId = data.MasterFeatureId;
            featuremodel.MasterFeatureTitle = data.MasterFeatureTitle;
            featuremodel.MasterFeatureBreef = data.MasterFeatureBreef;
            featuremodel.MasterFeatureDescription = data.MasterFeatureDescription;
            featuremodel.MasterFeatureImageUrl = data.MasterFeatureImageUrl;
            featuremodel.CreateUser = data.CreateUser;
            featuremodel.CreateDate = data.CreateDate;
            return View(featuremodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterFeatureViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterFeatureFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterFeature");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterFeatureFile.FileName);
                    ImageName = "MasterFeatureImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterFeatureFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new MasterFeature
                {
                    MasterFeatureId = collection.MasterFeatureId,
                    MasterFeatureTitle = collection.MasterFeatureTitle,
                    MasterFeatureBreef = collection.MasterFeatureBreef,
                    MasterFeatureDescription = collection.MasterFeatureDescription,
                    MasterFeatureImageUrl = (ImageName != "") ? ImageName : collection.MasterFeatureImageUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterFeature.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterFeature.Delete(Delete, new Models.MasterFeature { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
