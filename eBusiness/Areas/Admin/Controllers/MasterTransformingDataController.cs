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
    public class MasterTransformingDataController : Controller
    {
        public IRepository<MasterTransformingData> MasterTransformingData { get; }

        public UserManager<AppUser> UserManager { get; }

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterTransformingDataController(IRepository<MasterTransformingData> _masterTransformingData, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterTransformingData = _masterTransformingData;
            UserManager = _userManager;
            Hosting = _hosting;
        }

        public ActionResult Index()
        {
            var data = MasterTransformingData.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterTransformingData.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterTransformingData.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterTransformingDataViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterTransformingDataFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterTransformingData");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterTransformingDataFile.FileName);
                    ImageName = "MasterTransformingDataRateImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterTransformingDataFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                MasterTransformingData obj = new MasterTransformingData
                {
                    MasterTransformingDataId = collection.MasterTransformingDataId,
                    MasterTransformingDataRateImageUrl = ImageName,
                    MasterTransformingDataRateNumber = collection.MasterTransformingDataRateNumber,
                    MasterTransformingDataRateStar = collection.MasterTransformingDataRateStar,
                    MasterTransformingDataRateTitle = collection.MasterTransformingDataRateTitle,
                    MasterTransformingDataDescription = collection.MasterTransformingDataDescription,
                    MasterTransformingDataActiveClients = collection.MasterTransformingDataActiveClients,
                    MasterTransformingDataAnalyticsProjects = collection.MasterTransformingDataAnalyticsProjects,
                    MasterTransformingDataAutomationSuccess = collection.MasterTransformingDataAutomationSuccess,
                    MasterTransformingDataCloudReliability = collection.MasterTransformingDataCloudReliability,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterTransformingData.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var data = MasterTransformingData.Find(id);
            MasterTransformingDataViewModel transformingdatamodel = new MasterTransformingDataViewModel();
            transformingdatamodel.MasterTransformingDataId = data.MasterTransformingDataId;
            transformingdatamodel.MasterTransformingDataRateImageUrl = data.MasterTransformingDataRateImageUrl;
            transformingdatamodel.MasterTransformingDataRateNumber = data.MasterTransformingDataRateNumber;
            transformingdatamodel.MasterTransformingDataRateStar = data.MasterTransformingDataRateStar;
            transformingdatamodel.MasterTransformingDataRateTitle = data.MasterTransformingDataRateTitle;
            transformingdatamodel.MasterTransformingDataDescription = data.MasterTransformingDataDescription;
            transformingdatamodel.MasterTransformingDataActiveClients = data.MasterTransformingDataActiveClients;
            transformingdatamodel.MasterTransformingDataAnalyticsProjects = data.MasterTransformingDataAnalyticsProjects;
            transformingdatamodel.MasterTransformingDataAutomationSuccess = data.MasterTransformingDataAutomationSuccess;
            transformingdatamodel.MasterTransformingDataCloudReliability = data.MasterTransformingDataCloudReliability;
            transformingdatamodel.CreateUser = data.CreateUser;
            transformingdatamodel.CreateDate = data.CreateDate;
            return View(transformingdatamodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterTransformingDataViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterTransformingDataFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterTransformingData");
                    if (!Directory.Exists(PathImage))
                    {
                        Directory.CreateDirectory(PathImage);
                    }
                    FileInfo fi = new FileInfo(collection.MasterTransformingDataFile.FileName);
                    ImageName = "MasterTransformingDataRateImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterTransformingDataFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new MasterTransformingData
                {
                    MasterTransformingDataId = collection.MasterTransformingDataId,
                    MasterTransformingDataRateImageUrl = (ImageName != "") ? ImageName : collection.MasterTransformingDataRateImageUrl,
                    MasterTransformingDataRateNumber = collection.MasterTransformingDataRateNumber,
                    MasterTransformingDataRateStar = collection.MasterTransformingDataRateStar,
                    MasterTransformingDataRateTitle = collection.MasterTransformingDataRateTitle,
                    MasterTransformingDataDescription = collection.MasterTransformingDataDescription,
                    MasterTransformingDataActiveClients = collection.MasterTransformingDataActiveClients,
                    MasterTransformingDataAnalyticsProjects = collection.MasterTransformingDataAnalyticsProjects,
                    MasterTransformingDataAutomationSuccess = collection.MasterTransformingDataAutomationSuccess,
                    MasterTransformingDataCloudReliability = collection.MasterTransformingDataCloudReliability,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterTransformingData.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Delete)
        {
            MasterTransformingData.Delete(Delete, new Models.MasterTransformingData { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
