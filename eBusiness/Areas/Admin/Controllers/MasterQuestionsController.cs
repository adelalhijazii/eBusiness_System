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
    public class MasterQuestionsController : Controller
    {
        public IRepository<MasterQuestions> MasterQuestions { get; }

        public UserManager<AppUser> UserManager { get; }

        public MasterQuestionsController(IRepository<MasterQuestions> _masterQuestions, UserManager<AppUser> _userManager)
        {
            MasterQuestions = _masterQuestions;
            UserManager = _userManager;
        }

        public ActionResult Index()
        {
            var data = MasterQuestions.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterQuestions.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterQuestions.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterQuestionsViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterQuestions
                {
                    MasterQuestionsId = collection.MasterQuestionsId,
                    MasterQuestionsTitle = collection.MasterQuestionsTitle,
                    MasterQuestionsDescription = collection.MasterQuestionsDescription,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterQuestions.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterQuestions.Find(id);
            MasterQuestionsViewModel questionsmodel = new MasterQuestionsViewModel();
            questionsmodel.MasterQuestionsId = data.MasterQuestionsId;
            questionsmodel.MasterQuestionsTitle = data.MasterQuestionsTitle;
            questionsmodel.MasterQuestionsDescription = data.MasterQuestionsDescription;
            questionsmodel.CreateUser = data.CreateUser;
            questionsmodel.CreateDate = data.CreateDate;
            return View(questionsmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterQuestionsViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterQuestions
                {
                    MasterQuestionsId = collection.MasterQuestionsId,
                    MasterQuestionsTitle = collection.MasterQuestionsTitle,
                    MasterQuestionsDescription = collection.MasterQuestionsDescription,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterQuestions.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterQuestions.Delete(Delete, new Models.MasterQuestions { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
