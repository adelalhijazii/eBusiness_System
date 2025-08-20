using eBusiness.Models;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class MasterMenuViewModel : BaseEntity
    {
        public int MasterMenuId { get; set; }

        [DataType(DataType.Text)]
        public string MasterMenuName { get; set; }

        public string MasterMenuUrl { get; set; }
    }
}
