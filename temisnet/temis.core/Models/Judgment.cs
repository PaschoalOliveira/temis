using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    [Table("judgment")]
    public class Judgment
    {

        [ForeignKey("judging_instance_id")]
        [Column("judging_instance_id")]
        public long JudgmentInstanceId {get; set; }
        
        [ForeignKey("process_id")]
        [Column("process_id")]
        public long ProcessId {get; set; }

        [Column("date")]
        public DateTime JudgmentDate { get; set; }

        [Column("veredict")]
        public string Veredict {get;set; }

    }
}