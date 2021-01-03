using System.Collections.Generic;
using System.Threading.Tasks;
using temis.Core.Models;

namespace temis.Core.Interfaces
{
    public interface IProcessRepository
    {
         Process CreateProcess(Process member);
         Process EditProcess(Process member);
         Process ChangeStatus(Process process);
         PageResponse<Process> FindAll(PageRequest pageRequest);

         Task<PageResponse<Process>> FindAllAsync(PageRequest pageRequest);

         Process FindById(long id);
         Process FindByNumber(string processNumber);
         void Delete(long Id);
    }
}