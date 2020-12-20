using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.data.Data;
using MySql.Data.MySqlClient;

namespace temis.Data.Repositories
{
    public class ProcessRepository : IProcessRepository
    {
        private readonly TemisContext context;

        public ProcessRepository(TemisContext ctx)
        {
            context = ctx;
        }

        public Process CreateProcess(Process process)
        {
            Process processNew = context.Process.Add(process).Entity;
            return processNew;
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }
        public Process EditProcess(Process member)
        {
            throw new NotImplementedException();
        }

        public PageResponse<Process> FindAll(PageRequest pReq)
        {
            List<Process> processes = new List<Process>();
            processes = context.Process.ToList();
            PageResponse<Process> pResponse = PageResponse<Process>.For(processes, pReq, processes.Count);
            return pResponse;
        }

        public Process FindById(long id)
        {
            throw new NotImplementedException();
        }
    }
}