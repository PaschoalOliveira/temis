using System;
using System.Collections.Generic;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Core.Services.Service
{
    public class JudgmentService : IJudgmentService
    {
        private readonly IJudgmentRepository _repository;

        public JudgmentService(IJudgmentRepository repository)
        {
            _repository = repository;
        }

        public Judgment CreateJudgment(Judgment judgment)
        {
            Judgment judgmentNew = _repository.CreateJudgment(judgment);
            return judgmentNew;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Judgment EditJudgment(Judgment judgment)
        {
            Judgment judgmentNew = _repository.EditJudgment(judgment);
            return judgmentNew;
        }

        public List<Judgment> FindAll()
        {
            List<Judgment> list = new List<Judgment>();
            list = _repository.FindAll();
            return list;
        }

        public Judgment FindById(long id)
        {
            Judgment judgment = _repository.FindById(id);
            return judgment;
        }
    }
}
