using Microsoft.AspNetCore.Mvc;
using temis.Api.Controllers.Models.Requests;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Api.Controllers
{
    [ApiController]
    [Route("/api/judgment")]
    public class JudgmentController : ControllerBase
    {
         private IJudgmentService _judgmentService;

        public JudgmentController(IJudgmentService service)
        {
            _judgmentService = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {

            var judgment = _judgmentService.FindById(id);
            return Ok(judgment);
        }

        [HttpGet]
        public IActionResult Get(int? page, int? limit, string name = "")
        {
            return Ok("nao implementei");
        }


        [HttpPost]
        public IActionResult Post([FromBody] Judgment judgment)
        {

            Judgment judgmentClient = _judgmentService.CreateJudgment(judgment);
            if (judgmentClient != null) return Ok(judgmentClient);

            return BadRequest("Duplicate id or could not insert this judgment.");
        }


        [HttpPut]
        public IActionResult Put([FromBody] Judgment judgment)
        {
             _judgmentService.EditJudgment(judgment);
            return Ok(judgment);
        }


        [HttpPatch("edit")]
        public IActionResult Patch([FromBody] EditPasswordRequest request)
        {

            return Ok("nao implementei");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] long id)
        {
             bool judgmentNotFound = _judgmentService.FindById(id) == null;

            if (judgmentNotFound)
            {
                return NotFound("Judgment not found");
            }

            _judgmentService.Delete(id);
            return NoContent();
        }

    }
}
