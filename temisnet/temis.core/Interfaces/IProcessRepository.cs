using System.Collections.Generic;
using temis.Core.Models;

namespace temis.Core.Interfaces
{
    public interface IProcessRepository
    {
         Process CreateProcess(Process member);
         Process EditProcess(Process member);
         Process ChangeStatus(Process process);
         PageResponse<Process> FindAll(string number, PageRequest pageRequest);
         Process FindById(long id);
         Process FindByNumber(string processNumber);
         void Delete(long Id);
    }
}