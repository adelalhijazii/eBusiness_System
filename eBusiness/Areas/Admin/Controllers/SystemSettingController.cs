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
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSetting { get; }

        public UserManager<AppUser> UserManager { get; }

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public SystemSettingController(IRepository<SystemSetting> _systemSetting, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            SystemSetting = _systemSetting;
            UserManager = _userManager;
            Hosting = _hosting;
        }

        public ActionResult Index()
        {
            var data = SystemSetting.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = SystemSetting.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            SystemSetting.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SystemSettingViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string WelcomeNoteImageName = "";
                string AboutImageName1 = "";
                string AboutImageName2 = "";
                string AboutProfileImageName = "";
                if (collection.SystemSettingWelcomeNoteImageUrlFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/SystemSetting");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.SystemSettingWelcomeNoteImageUrlFile.FileName);
                    WelcomeNoteImageName = "SystemSettingWelcomeNoteImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, WelcomeNoteImageName);
                    collection.SystemSettingWelcomeNoteImageUrlFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                if (collection.SystemSettingAboutImageUrlFile1 != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/SystemSetting");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.SystemSettingAboutImageUrlFile1.FileName);
                    AboutImageName1 = "SystemSettingAboutImageUrl1" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, AboutImageName1);
                    collection.SystemSettingAboutImageUrlFile1.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                if (collection.SystemSettingAboutImageUrlFile2 != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/SystemSetting");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.SystemSettingAboutImageUrlFile2.FileName);
                    AboutImageName2 = "SystemSettingAboutImageUrl2" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, AboutImageName2);
                    collection.SystemSettingAboutImageUrlFile2.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                if (collection.SystemSettingAboutProfileImageUrlFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/SystemSetting");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.SystemSettingAboutProfileImageUrlFile.FileName);
                    AboutProfileImageName = "SystemSettingAboutProfileImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, AboutProfileImageName);
                    collection.SystemSettingAboutProfileImageUrlFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                SystemSetting obj = new SystemSetting
                {
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingLogoImageUrl = collection.SystemSettingLogoImageUrl,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDescription = collection.SystemSettingWelcomeNoteDescription,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingAboutTitle = collection.SystemSettingAboutTitle,
                    SystemSettingAboutBreef = collection.SystemSettingAboutBreef,
                    SystemSettingAboutDescription = collection.SystemSettingAboutDescription,
                    SystemSettingAboutProfileName = collection.SystemSettingAboutProfileName,
                    SystemSettingAboutProfilePosition = collection.SystemSettingAboutProfilePosition,
                    SystemSettingAboutIconPhone = collection.SystemSettingAboutIconPhone,
                    SystemSettingAboutPhone = collection.SystemSettingAboutPhone,
                    SystemSettingAboutExperience = collection.SystemSettingAboutExperience,
                    SystemSettingWelcomeNoteImageUrl = WelcomeNoteImageName,
                    SystemSettingAboutImageUrl1 = AboutImageName1,
                    SystemSettingAboutImageUrl2 = AboutImageName2,
                    SystemSettingAboutProfileImageUrl = AboutProfileImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                SystemSetting.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = SystemSetting.Find(id);
            SystemSettingViewModel systemsetting = new SystemSettingViewModel();
            systemsetting.SystemSettingId = data.SystemSettingId;
            systemsetting.SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl;
            systemsetting.SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle;
            systemsetting.SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef;
            systemsetting.SystemSettingWelcomeNoteDescription = data.SystemSettingWelcomeNoteDescription;
            systemsetting.SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl;
            systemsetting.SystemSettingCopyright = data.SystemSettingCopyright;
            systemsetting.SystemSettingAboutTitle = data.SystemSettingAboutTitle;
            systemsetting.SystemSettingAboutBreef = data.SystemSettingAboutBreef;
            systemsetting.SystemSettingAboutDescription = data.SystemSettingAboutDescription;
            systemsetting.SystemSettingAboutImageUrl1 = data.SystemSettingAboutImageUrl1;
            systemsetting.SystemSettingAboutImageUrl2 = data.SystemSettingAboutImageUrl2;
            systemsetting.SystemSettingAboutProfileImageUrl = data.SystemSettingAboutProfileImageUrl;
            systemsetting.SystemSettingAboutProfileName = data.SystemSettingAboutProfileName;
            systemsetting.SystemSettingAboutProfilePosition = data.SystemSettingAboutProfilePosition;
            systemsetting.SystemSettingAboutIconPhone = data.SystemSettingAboutIconPhone;
            systemsetting.SystemSettingAboutPhone = data.SystemSettingAboutPhone;
            systemsetting.SystemSettingAboutExperience = data.SystemSettingAboutExperience;
            systemsetting.CreateUser = data.CreateUser;
            systemsetting.CreateDate = data.CreateDate;
            return View(systemsetting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SystemSettingViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string WelcomeNoteImageName = "";
                string AboutImageName1 = "";
                string AboutImageName2 = "";
                string AboutProfileImageName = "";
                if (collection.SystemSettingWelcomeNoteImageUrlFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/SystemSetting");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.SystemSettingWelcomeNoteImageUrlFile.FileName);
                    WelcomeNoteImageName = "SystemSettingWelcomeNoteImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, WelcomeNoteImageName);
                    collection.SystemSettingWelcomeNoteImageUrlFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                if (collection.SystemSettingAboutImageUrlFile1 != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/SystemSetting");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.SystemSettingAboutImageUrlFile1.FileName);
                    AboutImageName1 = "SystemSettingAboutImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, AboutImageName1);
                    collection.SystemSettingAboutImageUrlFile1.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                if (collection.SystemSettingAboutImageUrlFile2 != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/SystemSetting");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.SystemSettingAboutImageUrlFile2.FileName);
                    AboutImageName2 = "SystemSettingAboutImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, AboutImageName2);
                    collection.SystemSettingAboutImageUrlFile2.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                if (collection.SystemSettingAboutProfileImageUrlFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/SystemSetting");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.SystemSettingAboutProfileImageUrlFile.FileName);
                    AboutProfileImageName = "SystemSettingAboutProfileImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, AboutProfileImageName);
                    collection.SystemSettingAboutProfileImageUrlFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new SystemSetting
                {
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingLogoImageUrl = collection.SystemSettingLogoImageUrl,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDescription = collection.SystemSettingWelcomeNoteDescription,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingAboutTitle = collection.SystemSettingAboutTitle,
                    SystemSettingAboutBreef = collection.SystemSettingAboutBreef,
                    SystemSettingAboutDescription = collection.SystemSettingAboutDescription,
                    SystemSettingAboutProfileName = collection.SystemSettingAboutProfileName,
                    SystemSettingAboutProfilePosition = collection.SystemSettingAboutProfilePosition,
                    SystemSettingAboutIconPhone = collection.SystemSettingAboutIconPhone,
                    SystemSettingAboutPhone = collection.SystemSettingAboutPhone,
                    SystemSettingWelcomeNoteImageUrl = (WelcomeNoteImageName != "") ? WelcomeNoteImageName : collection.SystemSettingWelcomeNoteImageUrl,
                    SystemSettingAboutImageUrl1 = (AboutImageName1 != "") ? AboutImageName1 : collection.SystemSettingAboutImageUrl1,
                    SystemSettingAboutImageUrl2 = (AboutImageName2 != "") ? AboutImageName2 : collection.SystemSettingAboutImageUrl2,
                    SystemSettingAboutProfileImageUrl = (AboutProfileImageName != "") ? AboutProfileImageName : collection.SystemSettingAboutProfileImageUrl,
                    SystemSettingAboutExperience = collection.SystemSettingAboutExperience,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                SystemSetting.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            SystemSetting.Delete(Delete, new Models.SystemSetting { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
