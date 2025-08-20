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
    public class MasterContactUsInformationController : Controller
    {
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }

        public UserManager<AppUser> UserManager { get; }

        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> _masterContactUsInformation, UserManager<AppUser> _userManager)
        {
            MasterContactUsInformation = _masterContactUsInformation;
            UserManager = _userManager;
        }

        public ActionResult Index()
        {
            var data = MasterContactUsInformation.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterContactUsInformation.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterContactUsInformation.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterContactUsInformationViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterContactUsInformation
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationIcon = collection.MasterContactUsInformationIcon,
                    MasterContactUsInformationDescription = collection.MasterContactUsInformationDescription,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterContactUsInformation.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterContactUsInformation.Find(id);
            MasterContactUsInformationViewModel contactusinformationmodel = new MasterContactUsInformationViewModel();
            contactusinformationmodel.MasterContactUsInformationId = data.MasterContactUsInformationId;
            contactusinformationmodel.MasterContactUsInformationIcon = data.MasterContactUsInformationIcon;
            contactusinformationmodel.MasterContactUsInformationDescription = data.MasterContactUsInformationDescription;
            contactusinformationmodel.CreateUser = data.CreateUser;
            contactusinformationmodel.CreateDate = data.CreateDate;
            return View(contactusinformationmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterContactUsInformationViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterContactUsInformation
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationIcon = collection.MasterContactUsInformationIcon,
                    MasterContactUsInformationDescription = collection.MasterContactUsInformationDescription,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterContactUsInformation.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterContactUsInformation.Delete(Delete, new Models.MasterContactUsInformation { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
