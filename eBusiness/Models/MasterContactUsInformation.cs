using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class MasterContactUsInformation : BaseEntity
    {
        public int MasterContactUsInformationId { get; set; }

        public string MasterContactUsInformationIcon { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterContactUsInformationDescription { get; set; }
    }
}
