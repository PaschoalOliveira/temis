using System.Threading.Tasks;
using temis.Core.Models;

namespace temis.Core.Services.Interfaces
{
    public interface IProcessService
    {
         Process CreateProcess(Process process);
         Process ChangeStatus(Process process);

         PageResponse<Process> FindAll(string number, PageRequest pReq);
         Task<PageResponse<Process>> FindAllAsync(PageRequest pReq);
         bool FindByCpf(string cpf);
         Process FindById(long id);
         void Delete(long Id);
    }
}