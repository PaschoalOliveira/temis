using System.Collections.Generic;
using temis.Core.Models;

namespace temis.Core.Services.Interfaces
{
    public interface IProcessService
    {
         Process CreateProcess(Process process);
         Process EditProcess(Process process);
         List<Process> FindAll();
         Process FindById(long id);
         void Delete(long Id);
    }
}