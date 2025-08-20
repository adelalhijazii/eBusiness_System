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
    public class TransactionNewsLetterController : Controller
    {
        public IRepository<TransactionNewsLetter> TransactionNewsLetter { get; }
        public UserManager<AppUser> UserManager { get; }

        public TransactionNewsLetterController(IRepository<TransactionNewsLetter> _transactionNewsLetter, UserManager<AppUser> _userManager)
        {
            TransactionNewsLetter = _transactionNewsLetter;
            UserManager = _userManager;
        }

        public ActionResult Index()
        {
            var data = TransactionNewsLetter.View();
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var data = TransactionNewsLetter.Find(id);
            TransactionNewsLetterViewModel newslettermodel = new TransactionNewsLetterViewModel();
            newslettermodel.TransactionNewsLetterId = data.TransactionNewsLetterId;
            newslettermodel.TransactionNewsLetterEmail = data.TransactionNewsLetterEmail;
            newslettermodel.CreateUser = data.CreateUser;
            newslettermodel.CreateDate = data.CreateDate;
            return View(newslettermodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TransactionNewsLetterViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new TransactionNewsLetter
                {
                    TransactionNewsLetterId = collection.TransactionNewsLetterId,
                    TransactionNewsLetterEmail = collection.TransactionNewsLetterEmail,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now
                };
                TransactionNewsLetter.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            TransactionNewsLetter.Delete(Delete, new Models.TransactionNewsLetter { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
