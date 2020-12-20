using Microsoft.AspNetCore.Mvc;
using temis.Api.Controllers.Models.Requests;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Api.Controllers
{
    [ApiController]
    [Route("/api/process")]
    public class ProcessController : ControllerBase
    {
        private IProcessService _processService;

        public ProcessController(IProcessService service)
        {
            _processService = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var process = _processService.FindById(id);

            return Ok(process);
        }

        [HttpGet]
        public IActionResult Get(int? page, int? limit, string description = "")
        {
            PageRequest pReq = PageRequest.Of(page, limit);
            PageResponse<Process> processes = _processService.FindAll(pReq);
            return Ok(processes.Content);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Process process)
        {
            Process processClient = _processService.CreateProcess(process);
            if (processClient != null) return Ok(processClient);

            return BadRequest("Duplicate id or could not insert this process.");
        }


        [HttpPut]
        public IActionResult Put([FromBody] Process process)
        {
            _processService.EditProcess(process);
            return Ok(process);
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
