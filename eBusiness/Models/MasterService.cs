using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class MasterService : BaseEntity
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
    }
}
