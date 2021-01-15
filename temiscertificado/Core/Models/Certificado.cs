using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    [Table("certificado")]
    public class Certificado
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("apto")]
        public bool Apto { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

    }
}