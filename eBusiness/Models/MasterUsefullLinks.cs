using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class MasterUsefullLinks : BaseEntity
    {
        public int MasterUsefullLinksId { get; set; }

        [DataType(DataType.Text)]
        public string MasterUsefullLinksName { get; set; }

        public string MasterUsefullLinksUrl { get; set; }
    }
}
