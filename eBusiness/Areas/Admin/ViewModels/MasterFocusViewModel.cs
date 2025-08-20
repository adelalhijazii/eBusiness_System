using eBusiness.Models;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class MasterFocusViewModel : BaseEntity
    {
        public int MasterFocusId { get; set; }

        [DataType(DataType.Text)]
        public string MasterFocusTitle { get; set; }

        [DataType(DataType.Text)]
        public string MasterFocusBreef { get; set; }

        public string MasterFocusPercentageRateIcon1 { get; set; }

        public string MasterFocusPercentageRate1 { get; set; }

        public string MasterFocusPercentageRateIcon2 { get; set; }

        public string MasterFocusPercentageRate2 { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterFocusDescription { get; set; }

        [DataType(DataType.ImageUrl)]
        public string MasterFocusImageUrl { get; set; }

        public IFormFile MasterFocusFile { get; set; }
    }
}
