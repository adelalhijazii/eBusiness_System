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
    public class TransactionContactUsController : Controller
    {
        public IRepository<TransactionContactUs> TransactionContactUs { get; }
        public UserManager<AppUser> UserManager { get; }

        public TransactionContactUsController(IRepository<TransactionContactUs> _transactionContactUs, UserManager<AppUser> _userManager)
        {
            TransactionContactUs = _transactionContactUs;
            UserManager = _userManager;
        }

        public ActionResult Index()
        {
            var data = TransactionContactUs.View();
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var data = TransactionContactUs.Find(id);
            TransactionContactUsViewModel contactusmodel = new TransactionContactUsViewModel();
            contactusmodel.TransactionContactUsId = data.TransactionContactUsId;
            contactusmodel.TransactionContactUsName = data.TransactionContactUsName;
            contactusmodel.TransactionContactUsEmail = data.TransactionContactUsEmail;
            contactusmodel.TransactionContactUsSubject = data.TransactionContactUsSubject;
            contactusmodel.TransactionContactUsMessage = data.TransactionContactUsMessage;
            contactusmodel.CreateUser = data.CreateUser;
            contactusmodel.CreateDate = data.CreateDate;
            return View(contactusmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TransactionContactUsViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new TransactionContactUs
                {
                    TransactionContactUsId = collection.TransactionContactUsId,
                    TransactionContactUsName = collection.TransactionContactUsName,
                    TransactionContactUsEmail = collection.TransactionContactUsEmail,
                    TransactionContactUsSubject = collection.TransactionContactUsSubject,
                    TransactionContactUsMessage = collection.TransactionContactUsMessage,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now
                };
                TransactionContactUs.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            TransactionContactUs.Delete(Delete, new Models.TransactionContactUs { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
