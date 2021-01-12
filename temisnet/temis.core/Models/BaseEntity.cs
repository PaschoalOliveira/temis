using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { set; get; }
    }
}