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
    public class JudgmentRepository : IJudgmentRepository
    {
        private readonly TemisContext context;

        public JudgmentRepository(TemisContext ctx)
        {
            context = ctx;
        }

        public Judgment CreateJudgment(Judgment judgment)
        {

            Judgment judgmentNew = context.Judgment.Add(judgment).Entity;
            context.SaveChanges();
            return judgmentNew;

        }

        public void Delete(long Id)
        {
            Judgment judgment = FindById(Id);
            context.Judgment.Remove(judgment);

            context.SaveChanges();
        }

        public Judgment EditJudgment(Judgment judgment)
        {                      
            var judgmentDate = new MySqlParameter("@judgmentDate", judgment.JudgmentDate);
            var judgmentVeredict = new MySqlParameter("@judgmentVeredict", judgment.Veredict);
            var judgmentProcessId = new MySqlParameter("@judgmentProcessId", judgment.ProcessId);
            var judgmentJudgmentInstanceId = new MySqlParameter("@judgmentJudgmentInstanceId", judgment.JudgmentInstanceId);

            context.Database.ExecuteSqlRaw(
                "UPDATE judgment SET date = @judgmentDate, veredict = @judgmentVeredict WHERE (process_id, judgment_instance_id) = (@judgmentProcessId, @judgmentJudgmentInstanceId)", 
                judgmentDate, judgmentVeredict, judgmentProcessId, judgmentJudgmentInstanceId);
            
            Judgment judgmentNew = FindById(judgment.JudgmentInstanceId);
            return judgmentNew;

        }

        public PageResponse<Judgment> FindAll(PageRequest pReq)
        {
            List<Judgment> judgments = new List<Judgment>();
            judgments = context.Judgment.ToList();
            PageResponse<Judgment> pResponse = PageResponse<Judgment>.For(judgments, pReq, judgments.Count);
            return pResponse;
        }

        public Judgment FindById(long id)
        {
            Judgment judgment = context.Judgment.Where(p => p.JudgmentInstanceId == id).FirstOrDefault();
            return judgment;
        }
    }
}