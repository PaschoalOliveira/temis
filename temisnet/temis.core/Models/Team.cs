using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TeamId {get; set; }

        [Column("name")]
        public string Name {get; set; }

         [Column("description")]
        public string Description {get; set; }

    }
}