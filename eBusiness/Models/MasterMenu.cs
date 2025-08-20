using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class MasterMenu : BaseEntity
    {
        public int MasterMenuId { get; set; }

        [DataType(DataType.Text)]
        public string MasterMenuName { get; set; }

        public string MasterMenuUrl { get; set; }
    }
}
