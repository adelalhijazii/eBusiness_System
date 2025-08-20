using eBusiness.Models;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class MasterServicesViewModel : BaseEntity
    {
        public int MasterServicesId { get; set; }

        public string MasterServicesIcon { get; set; }

        [DataType(DataType.Text)]
        public string MasterServicesTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterServicesDescription { get; set; }

        public string MasterServicesUrl { get; set; }

        [DataType(DataType.Text)]
        public string MasterServicesDetailsList { get; set; }

        public string MasterServicesDetailsIconPhone { get; set; }

        [DataType(DataType.Text)]
        public string MasterServicesDetailsPhone { get; set; }

        public string MasterServicesDetailsIconEmail { get; set; }

        [DataType(DataType.EmailAddress)]
        public string MasterServicesDetailsEmail { get; set; }

        [DataType(DataType.ImageUrl)]
        public string MasterServicesDetailsImageUrl { get; set; }

        public IFormFile MasterServicesDetailsFile { get; set; }

        [DataType(DataType.Text)]
        public string MasterServicesDetailsTitle { get; set; }

        [DataType(DataType.Text)]
        public string MasterServicesDetailsBreef { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterServicesDetailsListDescription { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterServicesDetailsFullDescription { get; set; }
    }
}
