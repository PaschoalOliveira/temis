using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    [Table("pessoa_fisica")]
    public class PessoaFisica : BaseEntity
    {
        
        [Column("name")]
        public string Name { get; set; }

        [Column("cpf")]
        [Required(ErrorMessage = "CPF is required")]
        public string Cpf { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("age")]
        public int Age { get; set; }

    }
}