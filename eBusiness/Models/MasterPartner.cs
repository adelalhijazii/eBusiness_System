using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class MasterPartner : BaseEntity
    {
        public int MasterPartnerId { get; set; }

        [DataType(DataType.ImageUrl)]
        public string MasterPartnerLogoImageUrl { get; set; }

        [DataType(DataType.Url)]
        public string MasterPartnerWebsiteUrl { get; set; }
    }
}
