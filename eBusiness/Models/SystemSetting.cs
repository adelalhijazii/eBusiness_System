using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class SystemSetting : BaseEntity
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

        public string SystemSettingCopyright { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingAboutTitle { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingAboutBreef { get; set; }

        [DataType(DataType.MultilineText)]
        public string SystemSettingAboutDescription { get; set; }

        [DataType(DataType.ImageUrl)]
        public string SystemSettingAboutImageUrl1 { get; set; }

        [DataType(DataType.ImageUrl)]
        public string SystemSettingAboutImageUrl2 { get; set; }

        [DataType(DataType.ImageUrl)]
        public string SystemSettingAboutProfileImageUrl { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingAboutProfileName { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingAboutProfilePosition { get; set; }

        public string SystemSettingAboutIconPhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string SystemSettingAboutPhone { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingAboutExperience { get; set; }
    }
}
