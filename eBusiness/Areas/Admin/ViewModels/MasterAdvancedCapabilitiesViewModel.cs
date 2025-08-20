using eBusiness.Models;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class MasterAdvancedCapabilitiesViewModel : BaseEntity
    {
        public int MasterAdvancedCapabilitiesId { get; set; }

        [DataType(DataType.Text)]
        public string MasterAdvancedCapabilitiesTitle { get; set; }

        [DataType(DataType.Text)]
        public string MasterAdvancedCapabilitiesBreef { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterAdvancedCapabilitiesDescription { get; set; }

        [DataType(DataType.Text)]
        public string MasterAdvancedCapabilitiesIcon { get; set; }
    }
}
