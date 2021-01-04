using System;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using temis.Api.Controllers.Models.Requests;
using temis.Api.Models.DTO;
using temis.Api.Models.ViewModel;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Api.v1.Controllers

{
    /// <summary>
    /// ProcessController
    /// </summary>
    [ApiController]
    [Route("/api/v1/process")]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;
        private readonly IMemoryCache _cache;
        private IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="processService"></param>
        /// <param name="mapper"></param>
        public ProcessController(IProcessService service, IMapper mapper, IMemoryCache cache)
        {
            _processService = service;
            _mapper = mapper;
            _cache = cache;
        }

        /// <summary>
        /// Get process by id number
        /// </summary>
        /// <param name="idMember"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
           // Process process = _processService.FindById(id);
            //ProcessDto viewModel = _mapper.Map<ProcessDto>(process);

            //return Ok(viewModel);

            var processEntity = _processService.FindById(id);
            return Ok(_mapper.Map<ProcessViewModel>(processEntity));
        }

        /// <summary>
        /// Get all process
        /// </summary>
        /// <param name="idMember"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpGet]
        public IActionResult Get(int? page, int? limit, string number = "")
        {
            var cacheEntry = _cache.GetOrCreate("Key", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                    entry.SetPriority(CacheItemPriority.High);

                PageRequest pReq = PageRequest.Of(page, limit);
                
                Thread.Sleep(10000);
                
                PageResponse<Process> processes = _processService.FindAll(number, pReq);
                PageProcessDto viewModel = _mapper.Map<PageProcessDto>(processes);
                return Ok(viewModel);
            });
                    return cacheEntry;
        }


        [HttpGet("number/{number}")]
        public IActionResult Get(string number)
        {
            Process process = _processService.FindByNumber(number);
            ProcessDto viewModel = _mapper.Map<ProcessDto>(process);

            return Ok(viewModel);
        }

        /// <summary>
        /// Cria um processo
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpPost]
        public IActionResult Post([FromBody] ProcessDto process)
        {
          //  Process processClient = _processService.CreateProcess(process);
          //  var viewModel = _mapper.Map<ProcessDto>(processClient);
          //  if (viewModel != null) return Ok(viewModel);
          //  return BadRequest("Duplicate id or could not insert this process.");

            var processEntity = _processService.CreateProcess(_mapper.Map<Process>(process));
            return Ok(_mapper.Map<ProcessViewModel>(processEntity));
        }

        /// <summary>
        /// Altera um processo cadastrado
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpPut]
        public IActionResult Put([FromBody] Process process)
        {
          //  _processService.EditProcess(process);
           // var viewModel = _mapper.Map<ProcessDto>(process);
          //  return Ok(viewModel);

            var processEntity = _processService.EditProcess(_mapper.Map<Process>(process));
            return Ok(_mapper.Map<ProcessViewModel>(processEntity));
        }

        /// <summary>
        /// Altera parcialmente o processo
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpPatch]
        public IActionResult Patch([FromBody] ChangeStatusRequest request)
        {
            Process process = _processService.FindById(request.Id);

            if (process == null)
            {
                return NotFound("Process not found");
            }

            process.Status = request.Status;

            _processService.ChangeStatus(process);

            var viewModel = _mapper.Map<ProcessDto>(process);
            return Ok(viewModel);
        }

        /// <summary>
        /// Processo delete.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Delete /api/process/{id}
        ///     
        /// </remarks>  
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

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
