using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    [Table("process")]
    public class Process
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long ProcessId {get; set; }

        [Column("status")]
        public string Status;

        [Column("status_update")]
        public DateTime StatusUpdate;

        [Column("create_date")]
        public DateTime CreationDate { get; set; }

        public Process()
        {
            this.CreationDate = DateTime.Now;
        }

    }
}