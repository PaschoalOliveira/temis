using System.Collections.Generic;
using System.Threading.Tasks;
using temis.Core.Models;

namespace temis.Core.Interfaces
{
    public interface IProcessRepository
    {
         Process CreateProcess(Process member);
         Process ChangeStatus(Process process);
         PageResponse<Process> FindAll(string number, PageRequest pageRequest);
         Task<PageResponse<Process>> FindAllAsync(PageRequest pageRequest);
         Process FindById(long id);
         void Delete(long Id);
    }
}