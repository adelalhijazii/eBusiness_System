using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class MasterAboutUs : BaseEntity
    {
        public int MasterAboutUsId { get; set; }

        [DataType(DataType.Text)]
        public string MasterAboutUsTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterAboutUsDescription { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MasterAboutUsPhone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string MasterAboutUsEmail { get; set; }
    }
}
