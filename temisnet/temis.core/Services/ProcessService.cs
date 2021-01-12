using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Core.Services.Service
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository _repository;
        private readonly IJudgmentRepository _judgementRepository;

        public ProcessService(IProcessRepository repository, IJudgmentRepository judgementRepository)
        {
            _repository = repository;
            _judgementRepository = judgementRepository;

        }

        public Process CreateProcess(Process process)
        {
            Process processNew = _repository.CreateProcess(process);
            return processNew;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Process ChangeStatus(Process process)
        {
            Process updateProcess = FindById(process.Id);
            updateProcess.Status = process.Status;
            updateProcess.StatusUpdate = DateTime.Now;
            
            return _repository.ChangeStatus(updateProcess);
        }
        public PageResponse<Process> FindAll(string number,PageRequest pageRequest)
        {
            PageResponse<Process> listProcess = _repository.FindAll(number, pageRequest);
            
            return listProcess;
        }

        public async Task<PageResponse<Process>> FindAllAsync(PageRequest pageRequest)
        {
            PageResponse<Process> listProcess =  await _repository.FindAllAsync(pageRequest);
            
            return listProcess;
        }

        public Process FindById(long id)
        {
            Process process = _repository.FindById(id);
            return process;
        }

              
    }
}
