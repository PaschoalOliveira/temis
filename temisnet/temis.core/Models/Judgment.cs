using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.core.Models
{
    public class Judgment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long JudgmentId {get; set; }

        [Column("date")]
        public DateTime JudgmentDate { get; set; }

        [Column("veredict")]
        public string Veredict {get;set; }

        [ForeignKey("process_id")]
        public long ProcessId {get; set; }

    }
}