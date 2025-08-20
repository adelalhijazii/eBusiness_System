using eBusiness.Models;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class MasterFeaturesViewModel : BaseEntity
    {
        public int MasterFeaturesId { get; set; }

        public string MasterFeaturesIcon { get; set; }

        [DataType(DataType.Text)]
        public string MasterFeaturesTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterFeaturesDescription { get; set; }
    }
}
