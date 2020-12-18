using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    [Table("member")]
    public class Member
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {get; set; }
        
        [Column("name")]
        public string Name { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("cpf")]
        [StringLength(11)]
        [Required(ErrorMessage = "CPF is required")]
        public string CPF { get; set; }

        public Member (long id, string name,  string lastName, int age, string role, string cpf)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.LastName = lastName;
            this.Role = role;
            this.CPF = cpf;

        }

        public Member() {}

    }
}