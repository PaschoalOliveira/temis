using System.Collections.Generic;
using temis.Core.Models;

namespace temis.Core.Services.Interfaces
{
    public interface IProcessService
    {
         Process CreateProcess(Process process);
         Process EditProcess(Process process);
         Process ChangeStatus(Process process);
         PageResponse<Process> FindAll(PageRequest pReq);
         Process FindById(long id);
         Process FindByNumber(string processNumber);
         void Delete(long Id);
    }
}