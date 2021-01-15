using temis.Core.Models;

namespace temis.Core.Services.Interfaces
{
    public interface IJudgmentService
    {
         Judgment CreateJudgment(Judgment judgment);
         Judgment EditJudgment(Judgment judgment);
         PageResponse<Judgment> FindAll(PageRequest pReq);
         Judgment FindById(long id);
         void Delete(long Id);
    }
}