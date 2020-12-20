using System.Collections.Generic;
using temis.Core.Models;

namespace temis.Core.Interfaces
{
    public interface IProcessRepository
    {
         Process CreateProcess(Process member);
         Process EditProcess(Process member);
         List<Member> FindAll();
         Process FindById(long id);
         void Delete(long Id);
    }
}