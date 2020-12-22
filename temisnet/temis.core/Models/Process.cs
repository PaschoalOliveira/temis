using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    [Table("process")]
    public class Process
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long ProcessId { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("status_update")]
        public DateTime StatusUpdate { get; set; }

        [Column("create_date")]
        public DateTime CreationDate { get; set; }

        [Column("number")]
        public string Number { get; set; }

        [NotMapped]
        [InverseProperty("Process")]
        public IEnumerable<Judgment> Judgments {get; set;} 


        public Process()
        {
            Random random = new Random();
            string convertRandom = random.ToString();

            this.CreationDate = DateTime.Now;
            this.Number = ($"{convertRandom}-{CreationDate}");
        }
    }
}