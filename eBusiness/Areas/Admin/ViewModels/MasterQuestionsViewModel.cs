using eBusiness.Models;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class MasterQuestionsViewModel : BaseEntity
    {
        public int MasterQuestionsId { get; set; }

        [DataType(DataType.Text)]
        public string MasterQuestionsTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterQuestionsDescription { get; set; }
    }
}
