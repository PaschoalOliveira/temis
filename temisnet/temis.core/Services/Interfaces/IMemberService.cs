using System.Collections.Generic;
using temis.Core.Models;

namespace temis.Core.Services.Interfaces
{
    public interface IMemberService
    {
         Member CreateMember(Member member);
         Member EditMember(Member member);
         List<Member> FindAll();
         Member FindById(long id);
         void EditPassword(long id, string password);
         void Delete(long Id);
         PageResponse<Member> Filter (string name, PageRequest pageRequest);
    }
}