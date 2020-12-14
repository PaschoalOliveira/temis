using System.Text.Json.Serialization;

namespace temis.api.Models
{
    public class Membro
    {
        public Membro()
        {
        }

        public Membro(int MembroId, string Nome)
        {
            this.MembroId = MembroId;
            this.Nome = Nome;

        }
        
        public int MembroId { get; set; }
        public string Nome { get; set; }
    }
}