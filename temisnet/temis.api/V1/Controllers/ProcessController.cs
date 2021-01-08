using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using temis.api.Requests;
using temis.Api.Controllers.Models.Requests;
using temis.Api.Models.DTO;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace temis.Api.v1.Controllers
{
    /// <summary>
    /// ProcessController
    /// </summary>
    [ApiController]
    [Route("/api/v1/process")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;
        private readonly IDistributedCache _cacheRedis;
        private const string ProcessKey = "Process";
        private IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProcessController(IProcessService service, IMapper mapper, IDistributedCache cacheRedis)
        {
            _processService = service;
            _mapper = mapper;
            _cacheRedis = cacheRedis;
        }

        /// <summary>
        /// Get all process
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpGet]
        public IActionResult Get(int? page, int? limit, string number = "")
        {
            var json = _cacheRedis.GetString(ProcessKey);

            if (json != null)
            {

                var process = System.Text.Json.JsonSerializer.Deserialize<PageProcessDto>(json);
                return Ok(process);
            }

            var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(20))
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

            PageRequest pReq = PageRequest.Of(page, limit);

            Thread.Sleep(1000);

            PageResponse<Process> processes = _processService.FindAll(number, pReq);
            PageProcessDto viewModel = _mapper.Map<PageProcessDto>(processes);

            string jsonFinaly = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            _cacheRedis.SetString(ProcessKey, jsonFinaly, options);

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
        public IActionResult Post([FromBody] CreateProcessRequest request)
        {

            Process processMap = _mapper.Map<Process>(request);
            Process processEntity = _processService.CreateProcess(processMap);

            if (processEntity == null) return NoContent();

            return Ok(_mapper.Map<ProcessDto>(processEntity));

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
