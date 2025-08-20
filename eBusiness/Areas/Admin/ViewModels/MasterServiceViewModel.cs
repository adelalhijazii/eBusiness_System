using eBusiness.Models;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class MasterServiceViewModel : BaseEntity
    {
        public int MasterServiceId { get; set; }

        public string MasterServiceIcon { get; set; }

        [DataType(DataType.Text)]
        public string MasterServiceTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterServiceDescription { get; set; }

        [DataType(DataType.ImageUrl)]
        public string MasterServiceImageUrl { get; set; }

        public string MasterServiceUrl { get; set; }

        public IFormFile MasterServiceFile { get; set; }
    }
}
