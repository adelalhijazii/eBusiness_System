using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class MasterTeam : BaseEntity
    {
        public int MasterTeamId { get; set; }

        [DataType(DataType.Text)]
        public string MasterTeamTitle { get; set; }

        [DataType(DataType.Text)]
        public string MasterTeamBreef { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterTeamDescription { get; set; }

        public string MasterTeamIcon { get; set; }

        [DataType(DataType.Url)]
        public string MasterTeamIconUrl { get; set; }

        [DataType(DataType.ImageUrl)]
        public string MasterTeamImageUrl { get; set; }
    }
}
