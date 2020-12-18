using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.core.Models
{
    public class Judgment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long JudgmentId {get; set; }

        [ForeignKey("judgment_instance_id")]
        public long JudgmentInstanceId {get; set; }
        
        [ForeignKey("process_id")]
        public long ProcessId {get; set; }

        [Column("date")]
        public DateTime JudgmentDate { get; set; }

        [Column("veredict")]
        public string Veredict {get;set; }

    }
}