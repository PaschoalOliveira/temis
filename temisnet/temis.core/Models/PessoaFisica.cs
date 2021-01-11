using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    [Table("pessoa_fisica")]
    public class PessoaFisica
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {get; set; }
        
        [Column("name")]
        public string Name { get; set; }

        [Column("cpf")]
        [Required(ErrorMessage = "CPF is required")]
        public string Cpf { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("age")]
        public int Age { get; set; }

        public PessoaFisica (long id, string name,  string lastName, int age, string role, string cpf, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Cpf = cpf;
        }

        public PessoaFisica() {}

    }
}