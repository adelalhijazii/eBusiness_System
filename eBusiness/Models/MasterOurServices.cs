using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class MasterOurServices : BaseEntity
    {
        public int MasterOurServicesId { get; set; }

        [DataType(DataType.Text)]
        public string MasterOurServicesName { get; set; }

        public string MasterOurServicesUrl { get; set; }
    }
}
