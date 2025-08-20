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
    public class MasterTeamController : Controller
    {
        public IRepository<MasterTeam> MasterTeam { get; }

        public UserManager<AppUser> UserManager { get; }

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterTeamController(IRepository<MasterTeam> _masterTeam, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterTeam = _masterTeam;
            UserManager = _userManager;
            Hosting = _hosting;
        }
        
        public ActionResult Index()
        {
            var data = MasterTeam.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterTeam.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterTeam.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterTeamViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterTeamFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterTeam");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterTeamFile.FileName);
                    ImageName = "MasterTeamImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterTeamFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                MasterTeam obj = new MasterTeam
                {
                    MasterTeamId = collection.MasterTeamId,
                    MasterTeamTitle = collection.MasterTeamTitle,
                    MasterTeamBreef = collection.MasterTeamBreef,
                    MasterTeamDescription = collection.MasterTeamDescription,
                    MasterTeamImageUrl = ImageName,
                    MasterTeamIcon = collection.MasterTeamIcon,
                    MasterTeamIconUrl = collection.MasterTeamIconUrl,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterTeam.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterTeam.Find(id);
            MasterTeamViewModel teammodel = new MasterTeamViewModel();
            teammodel.MasterTeamId = data.MasterTeamId;
            teammodel.MasterTeamTitle = data.MasterTeamTitle;
            teammodel.MasterTeamBreef = data.MasterTeamBreef;
            teammodel.MasterTeamDescription = data.MasterTeamDescription;
            teammodel.MasterTeamImageUrl = data.MasterTeamImageUrl;
            teammodel.MasterTeamIcon = data.MasterTeamIcon;
            teammodel.MasterTeamIconUrl = data.MasterTeamIconUrl;
            teammodel.CreateUser = data.CreateUser;
            teammodel.CreateDate = data.CreateDate;
            return View(teammodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterTeamViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterTeamFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterTeam");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterTeamFile.FileName);
                    ImageName = "MasterTeamImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterTeamFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new MasterTeam
                {
                    MasterTeamId = collection.MasterTeamId,
                    MasterTeamTitle = collection.MasterTeamTitle,
                    MasterTeamBreef = collection.MasterTeamBreef,
                    MasterTeamDescription = collection.MasterTeamDescription,
                    MasterTeamImageUrl = (ImageName != "") ? ImageName : collection.MasterTeamImageUrl,
                    MasterTeamIcon = collection.MasterTeamIcon,
                    MasterTeamIconUrl = collection.MasterTeamIconUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterTeam.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterTeam.Delete(Delete, new Models.MasterTeam { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
