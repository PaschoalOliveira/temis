using System;
using System.Collections.Generic;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Core.Services.Service
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository _repository;

        public ProcessService(IProcessRepository repository)
        {
            _repository = repository;
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

        public Process EditProcess(Process process)
        {
            Process editedProcess = _repository.EditProcess(process);
            return editedProcess;
        }
        public PageResponse<Process> FindAll(PageRequest pageRequest)
        {
            PageResponse<Process> listProcess = _repository.FindAll(pageRequest);
            //listProcess = _repository.FindAll();
            return listProcess;
        }

        public Process FindById(long id)
        {
            Process process = _repository.FindById(id);
            return process;
        }

        public Process FindByNumber(string processNumber) => _repository.FindByNumber(processNumber);
        
    }
}
