namespace temis.api.Models
{
    public class Processo
    {
        public Processo()
        {

        }
        public Processo(int id, string nomeProcesso, int membroId, Membro membro)
        {
            this.Id = id;
            this.NomeProcesso = nomeProcesso;
            this.MembroId = membroId;
            this.Membro = membro;

        }
        public int Id { get; set; }
        public string NomeProcesso { get; set; }

        public int MembroId { get; set; }

        public Membro Membro { get; set; }
    }
}