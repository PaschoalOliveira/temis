using System.ComponentModel.DataAnnotations.Schema;

namespace temis.core.Models
{
    public class TeamMember
    {
        [ForeignKey("member_id")]
        public long MemberId {get; set; }

        [ForeignKey("team_id")]
        public long TeamId {get; set; }
    }
}