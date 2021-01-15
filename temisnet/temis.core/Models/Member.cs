using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace temis.Core.Models
{
    [Table("member")]
    public class Member : BaseEntity
    {

        [Column("role")]
        public string Role { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("cpf")]
        [Required(ErrorMessage = "CPF is required")]
        public string Cpf { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("age")]
        public int Age { get; set; }
        
        public Member (long id, string name,  string lastName, int age, string role, string cpf, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.LastName = lastName;
            this.Role = role;
            this.Cpf = cpf;
            this.Password = password;
        }

        public Member() {}

    }
}