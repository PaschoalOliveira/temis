using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using temis.Api.Controllers.Models.Requests;
using temis.Core.DTO;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Api.Controllers
{
    [ApiController]
    [Route("/api/process")]
    public class ProcessController : ControllerBase
    {
        private IProcessService _processService;
        private IMapper _mapper;

        public ProcessController(IProcessService service, IMapper mapper)
        {
            _processService = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var process = _processService.FindById(id);
            var viewModel = _mapper.Map<ProcessDto>(process);

            return Ok(viewModel);
        }

        [HttpGet]
        public IActionResult Get(int? page, int? limit, string description = "")
        {
            PageRequest pReq = PageRequest.Of(page, limit);
            PageResponse<Process> processes = _processService.FindAll(pReq);
            return Ok(processes.Content);
        }

        [HttpGet("number")]
        public IActionResult Get(string number)
        {
            var process = _processService.FindByNumber(number);
            var viewModel = _mapper.Map<ProcessDto>(number);

            return Ok(viewModel);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Process process)
        {
            Process processClient = _processService.CreateProcess(process);
            var viewModel = _mapper.Map<ProcessDto>(processClient);

            if (viewModel != null) return Ok(viewModel);

            return BadRequest("Duplicate id or could not insert this process.");
        }


        [HttpPut]
        public IActionResult Put([FromBody] Process process)
        {
            _processService.EditProcess(process);
            var viewModel = _mapper.Map<ProcessDto>(process);
            return Ok(viewModel);
        }


        [HttpPatch("edit")]
        public IActionResult Patch([FromBody] EditPasswordRequest request)
        {

            return Ok("nao implementei");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] long id)
        {
            bool processNotFound = _processService.FindById(id) == null;

            if (processNotFound)
            {
                return NotFound("Process not found");
            }

            _processService.Delete(id);
            return NoContent();
        }

    }
}
