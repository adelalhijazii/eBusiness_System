using eBusiness.Models;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class MasterWhyUsViewModel : BaseEntity
    {
        public int MasterWhyUsId { get; set; }

        [DataType(DataType.Text)]
        public string MasterWhyUsTitle { get; set; }

        [DataType(DataType.Text)]
        public string MasterWhyUsBreef { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterWhyUsDescription { get; set; }

        [DataType(DataType.ImageUrl)]
        public string MasterWhyUsImageUrl { get; set; }

        public IFormFile MasterWhyUsFile { get; set; }
    }
}
