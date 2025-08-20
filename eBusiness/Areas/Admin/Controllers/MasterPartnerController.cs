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
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartner { get; }

        public UserManager<AppUser> UserManager { get; }

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterPartnerController(IRepository<MasterPartner> _masterPartner, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterPartner = _masterPartner;
            UserManager = _userManager;
            Hosting = _hosting;
        }

        public ActionResult Index()
        {
            var data = MasterPartner.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterPartner.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterPartner.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterPartnerViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterPartnerFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterPartner");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterPartnerFile.FileName);
                    ImageName = "MasterPartnerImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterPartnerFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                MasterPartner obj = new MasterPartner
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                    MasterPartnerLogoImageUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterPartner.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterPartner.Find(id);
            MasterPartnerViewModel featuremodel = new MasterPartnerViewModel();
            featuremodel.MasterPartnerId = data.MasterPartnerId;
            featuremodel.MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl;
            featuremodel.MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl;
            featuremodel.CreateUser = data.CreateUser;
            featuremodel.CreateDate = data.CreateDate;
            return View(featuremodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterPartnerViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterPartnerFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterPartner");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterPartnerFile.FileName);
                    ImageName = "MasterPartnerImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterPartnerFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new MasterPartner
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                    MasterPartnerLogoImageUrl = (ImageName != "") ? ImageName : collection.MasterPartnerLogoImageUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterPartner.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterPartner.Delete(Delete, new Models.MasterPartner { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
