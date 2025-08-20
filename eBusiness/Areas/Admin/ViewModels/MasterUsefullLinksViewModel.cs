using eBusiness.Models;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class MasterUsefullLinksViewModel : BaseEntity
    {
        public int MasterUsefullLinksId { get; set; }

        [DataType(DataType.Text)]
        public string MasterUsefullLinksName { get; set; }

        public string MasterUsefullLinksUrl { get; set; }
    }
}
