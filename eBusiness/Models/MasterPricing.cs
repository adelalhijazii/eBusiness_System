using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class MasterPricing : BaseEntity
    {
        public int MasterPricingId { get; set; }

        [DataType(DataType.Text)]
        public string MasterPricingTitle { get; set; }

        [DataType(DataType.Text)]
        public string MasterPricingBreef { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterPricingDescription { get; set; }

        public string MasterPricingUrl { get; set; }
    }
}
