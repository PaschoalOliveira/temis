using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    [Table("member_tbl")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public User (long id, string username,  string password, int idade, string name, string sobrenome)
        {
            this.Id = id;
            this.Username = username;
            this.Idade = idade;
            this.Password = password;
            this.Nome = name;
            this.Sobrenome = sobrenome;
        }

        public User() {}

    }
}