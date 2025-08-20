using eBusiness.Models;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class TransactionContactUsViewModel : BaseEntity
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
