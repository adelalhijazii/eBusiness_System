using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class MasterQuestions : BaseEntity
    {
        public int MasterQuestionsId { get; set; }

        [DataType(DataType.Text)]
        public string MasterQuestionsTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterQuestionsDescription { get; set; }
    }
}
