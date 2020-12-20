using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    public class JudgingInstance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long JudgingInstanceId {get; set; }

        [Column("level")]
        public string level {get;set;}

        [ForeignKey("member_id")]
        public long MemberId {get; set; }

        [ForeignKey("team_id")]
        public long TeamId {get; set; }

    }
}