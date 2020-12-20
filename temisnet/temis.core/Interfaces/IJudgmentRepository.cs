using System.Collections.Generic;
using temis.Core.Models;

namespace temis.Core.Interfaces
{
    public interface IJudgmentRepository
    {
        Judgment CreateJudgment(Judgment judgment);
        Judgment EditJudgment(Judgment judgment);
        List<Judgment> FindAll();
        Judgment FindById(long id);
        void Delete(long Id);
    }
}