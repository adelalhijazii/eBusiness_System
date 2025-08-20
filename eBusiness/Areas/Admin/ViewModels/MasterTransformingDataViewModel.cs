using eBusiness.Models;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class MasterTransformingDataViewModel : BaseEntity
    {
        public int MasterTransformingDataId { get; set; }

        [DataType(DataType.ImageUrl)]
        public string MasterTransformingDataRateImageUrl { get; set; }

        public IFormFile MasterTransformingDataFile { get; set; }

        [DataType(DataType.Text)]
        public string MasterTransformingDataRateNumber { get; set; }

        [DataType(DataType.Text)]
        public string MasterTransformingDataRateStar { get; set; }

        [DataType(DataType.Text)]
        public string MasterTransformingDataRateTitle { get; set; }

        [DataType(DataType.Text)]
        public string MasterTransformingDataDescription { get; set; }

        [DataType(DataType.Text)]
        public string MasterTransformingDataActiveClients { get; set; }

        [DataType(DataType.Text)]
        public string MasterTransformingDataAnalyticsProjects { get; set; }

        [DataType(DataType.Text)]
        public string MasterTransformingDataAutomationSuccess { get; set; }

        [DataType(DataType.Text)]
        public string MasterTransformingDataCloudReliability { get; set; }
    }
}
