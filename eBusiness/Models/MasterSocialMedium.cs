using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class MasterSocialMedium : BaseEntity
    {
        public int MasterSocialMediumId { get; set; }

        public string MasterSocialMediumIcon { get; set; }

        [DataType(DataType.Url)]
        public string MasterSocialMediumUrl { get; set; }
    }
}
