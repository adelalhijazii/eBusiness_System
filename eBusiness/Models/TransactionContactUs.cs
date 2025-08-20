using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class TransactionContactUs : BaseEntity
    {
        public int TransactionContactUsId { get; set; }

        [DataType(DataType.Text)]
        public string TransactionContactUsName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string TransactionContactUsEmail { get; set; }

        [DataType(DataType.Text)]
        public string TransactionContactUsSubject { get; set; }

        [DataType(DataType.MultilineText)]
        public string TransactionContactUsMessage { get; set; }
    }
}
