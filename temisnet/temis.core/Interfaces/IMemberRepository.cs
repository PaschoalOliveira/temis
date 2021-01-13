using System.Collections.Generic;
using temis.Core.Models;

namespace temis.Core.Interfaces
{
    public interface IMemberRepository : IRepository<Member> 
    {
         void EditPassword(long id, string password);
         Member Validate(string cpf, string password);
         PageResponse<PessoaFisica> Filter (string name, PageRequest pageRequest);
    }
}