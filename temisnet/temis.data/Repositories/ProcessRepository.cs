using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.data.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

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
            process.Status = "inicializado";
            context.Process.Add(process);
            context.SaveChanges();
            return process;
        }

        public void Delete(long Id)
        {
            var result = context.Process.Where((p) => p.Id == Id).SingleOrDefault();
             context.Remove(result);
             context.SaveChanges();
        }
      
        public Process ChangeStatus(Process process)
        {
            context.Process.Update(process);
            context.SaveChanges();
            return process;
        }

        public PageResponse<Process> FindAll(string number, PageRequest pageRequest)
        {
            IQueryable<Process> query = context.Process.Where(
                                    i => 
                                    i.Number.Contains(number)
                                    ).Include(j => j.Judgments)
                                     .OrderBy(u => u.StatusUpdate);

            List<Process> filtredProcess;
            filtredProcess = PaginationRepository<Process>.For(query, pageRequest).ToList();
            return PageResponse<Process>.For(filtredProcess, pageRequest, query.Count());
        }

        public async Task<PageResponse<Process>> FindAllAsync(PageRequest pReq)
        {
            List<Process> processes = new List<Process>();
            
            processes = await context.Process.ToListAsync();
            
            PageResponse<Process> pResponse = PageResponse<Process>.For(processes, pReq, processes.Count);
            return pResponse;
        }

        public Process FindById(long id)
        {
            return context.Process.Where((p) => p.Id == id).SingleOrDefault();
        }

        public bool FindByCpf(string cpf)
        {
            return context.Process.Any((p) => p.Cpf.Equals(cpf));
        }

      
    }
}