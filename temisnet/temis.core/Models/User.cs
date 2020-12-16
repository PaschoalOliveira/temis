using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    [Table("member_tbl")]
    public class User
    {
        
        [Key]
        public long Id {get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("idade")]
        public int Idade { get; set; }

        [Column("nome")]
        public string Nome { get; set; }
        
        [Column("sobrenome")]
        public string Sobrenome { get; set; }

    }
}