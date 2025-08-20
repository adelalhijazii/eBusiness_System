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
    public class MasterWhyUsController : Controller
    {
        public IRepository<MasterWhyUs> MasterWhyUs { get; }

        public UserManager<AppUser> UserManager { get; }

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterWhyUsController(IRepository<MasterWhyUs> _masterWhyUs, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterWhyUs = _masterWhyUs;
            UserManager = _userManager;
            Hosting = _hosting;
        }

        public ActionResult Index()
        {
            var data = MasterWhyUs.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterWhyUs.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterWhyUs.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterWhyUsViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterWhyUsFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterWhyUs");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterWhyUsFile.FileName);
                    ImageName = "MasterWhyUsImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterWhyUsFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                MasterWhyUs obj = new MasterWhyUs
                {
                    MasterWhyUsId = collection.MasterWhyUsId,
                    MasterWhyUsTitle = collection.MasterWhyUsTitle,
                    MasterWhyUsBreef = collection.MasterWhyUsBreef,
                    MasterWhyUsDescription = collection.MasterWhyUsDescription,
                    MasterWhyUsImageUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterWhyUs.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterWhyUs.Find(id);
            MasterWhyUsViewModel whyusmodel = new MasterWhyUsViewModel();
            whyusmodel.MasterWhyUsId = data.MasterWhyUsId;
            whyusmodel.MasterWhyUsTitle = data.MasterWhyUsTitle;
            whyusmodel.MasterWhyUsBreef = data.MasterWhyUsBreef;
            whyusmodel.MasterWhyUsDescription = data.MasterWhyUsDescription;
            whyusmodel.MasterWhyUsImageUrl = data.MasterWhyUsImageUrl;
            whyusmodel.CreateUser = data.CreateUser;
            whyusmodel.CreateDate = data.CreateDate;
            return View(whyusmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterWhyUsViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterWhyUsFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterWhyUs");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterWhyUsFile.FileName);
                    ImageName = "MasterWhyUsImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterWhyUsFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new MasterWhyUs
                {
                    MasterWhyUsId = collection.MasterWhyUsId,
                    MasterWhyUsTitle = collection.MasterWhyUsTitle,
                    MasterWhyUsBreef = collection.MasterWhyUsBreef,
                    MasterWhyUsDescription = collection.MasterWhyUsDescription,
                    MasterWhyUsImageUrl = (ImageName != "") ? ImageName : collection.MasterWhyUsImageUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterWhyUs.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterWhyUs.Delete(Delete, new Models.MasterWhyUs { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
