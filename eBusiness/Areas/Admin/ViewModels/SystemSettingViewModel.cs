using eBusiness.Models;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class SystemSettingViewModel : BaseEntity
    {
        public int SystemSettingId { get; set; }

        public string SystemSettingLogoImageUrl { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingWelcomeNoteTitle { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingWelcomeNoteBreef { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string SystemSettingWelcomeNoteDescription { get; set; }

        [DataType(DataType.ImageUrl)]
        public string SystemSettingWelcomeNoteImageUrl { get; set; }

        public IFormFile SystemSettingWelcomeNoteImageUrlFile { get; set; }

        public string SystemSettingCopyright { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingAboutTitle { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingAboutBreef { get; set; }

        [DataType(DataType.MultilineText)]
        public string SystemSettingAboutDescription { get; set; }

        [DataType(DataType.ImageUrl)]
        public string SystemSettingAboutProfileImageUrl { get; set; }

        public IFormFile SystemSettingAboutProfileImageUrlFile { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingAboutProfileName { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingAboutProfilePosition { get; set; }

        public string SystemSettingAboutIconPhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string SystemSettingAboutPhone { get; set; }

        [DataType(DataType.ImageUrl)]
        public string SystemSettingAboutImageUrl1 { get; set; }

        public IFormFile SystemSettingAboutImageUrlFile1 { get; set; }

        [DataType(DataType.ImageUrl)]
        public string SystemSettingAboutImageUrl2 { get; set; }

        public IFormFile SystemSettingAboutImageUrlFile2 { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingAboutExperience { get; set; }
    }
}
