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
            throw new NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public Judgment EditJudgment(Judgment judgment)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}