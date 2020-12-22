using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    [Table("judgment")]
    public class Judgment
    {
        [Column("judging_instance_id")]
        public long JudgmentInstanceId {get; set; }

        [ForeignKey("JudgingInstanceId")]
        public JudgingInstance JudgingInstance {get; set; }

        [Column("process_id")]
        public long ProcessId {get; set; }
        
        [ForeignKey("ProcessId")]
        public Process Process {get; set; }

        [Column("date")]
        public DateTime JudgmentDate { get; set; }

        [Column("veredict")]
        public string Veredict {get;set; }

    }
}