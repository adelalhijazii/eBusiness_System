namespace eBusiness.Models
{
    public class BaseEntity
    {
        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        //[Required]
        public string CreateUser { get; set; }

        //[Required]
        public DateTime? CreateDate { get; set; }

        //[Required]
        public string EditUser { get; set; }

        //[Required]
        public DateTime? EditDate { get; set; }
    }
}
