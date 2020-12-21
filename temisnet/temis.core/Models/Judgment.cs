using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    [Table("judgment")]
    public class Judgment
    {

        [Column("judging_instance_id")]
        public long JudgmentInstanceId {get; set; }
        
        [Column("process_id")]
        public long ProcessId {get; set; }

        [Column("date")]
        public DateTime JudgmentDate { get; set; }

        [Column("veredict")]
        public string Veredict {get;set; }

    }
}