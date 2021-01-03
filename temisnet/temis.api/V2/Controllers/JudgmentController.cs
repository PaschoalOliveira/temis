using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using temis.Api.Controllers.Models.Requests;
using temis.Api.Models.DTO;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Api.v2.Controllers
{
    [ApiController]
    [Route("/api/v2/judgment")]
    public class JudgmentController : ControllerBase
    {
         private IJudgmentService _judgmentService;
         private IMapper _mapper;

        public JudgmentController(IJudgmentService service, IMapper mapper)
        {
            _judgmentService = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {

            var judgment = _judgmentService.FindById(id);
            var viewModel = _mapper.Map<JudgmentDto>(judgment);

            return Ok(viewModel);
        }

        [HttpGet]
        public IActionResult Get(int? page, int? limit)
        {

            PageRequest pReq = PageRequest.Of(page, limit);
            PageResponse<Judgment> judgments = _judgmentService.FindAll(pReq);
            return Ok(judgments.Content);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Judgment judgment)
        {

            Judgment judgmentClient = _judgmentService.CreateJudgment(judgment);
            var viewModel = _mapper.Map<JudgmentDto>(judgmentClient);
            if (viewModel != null) return Ok(viewModel);

            return BadRequest("Duplicate id or could not insert this judgment.");
        }


        [HttpPut]
        public IActionResult Put([FromBody] Judgment judgment)
        {
             _judgmentService.EditJudgment(judgment);
            var viewModel = _mapper.Map<JudgmentDto>(judgment);
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
