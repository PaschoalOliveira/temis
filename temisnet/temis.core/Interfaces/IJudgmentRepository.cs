using System.Collections.Generic;
using temis.Core.Models;

namespace temis.Core.Interfaces
{
    public interface IJudgmentRepository
    {
        Judgment CreateJudgment(Judgment judgment);
        Judgment EditJudgment(Judgment judgment);
        PageResponse<Judgment> FindAll(PageRequest pReq);
        Judgment FindById(long id);
        Judgment FindByProcessId(long processId);
        void Delete(long Id);
    }
}