using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using temis.Api.Controllers.Models.Requests;
using temis.Api.Models.DTO;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Api.v2.Controllers
{
    [ApiController]
    [Route("/api/v2/process")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ExcludeFromCodeCoverageAttribute]
    public class ProcessController : ControllerBase
    {
        private IProcessService _processService;
        private IMapper _mapper;
        private readonly IDistributedCache _cacheRedis;
        private IMemoryCache _cache;
        private const string ProcessKey = "Process";

        public ProcessController(IProcessService service, IMapper mapper, IMemoryCache cache, IDistributedCache cacheRedis)
        {
            _processService = service;
            _mapper = mapper;
            _cache = cache;
            _cacheRedis = cacheRedis;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var process = _processService.FindById(id);
            var viewModel = _mapper.Map<ProcessDto>(process);

            return Ok(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? page, int? limit, string description = "")
        {
            var cacheEntry = await _cache.GetOrCreateAsync("Key", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10); // tempo de expiração
                entry.SetPriority(CacheItemPriority.High);

                PageRequest pReq = PageRequest.Of(page, limit);

                Thread.Sleep(10000);

                PageResponse<Process> processes = await _processService.FindAllAsync(pReq);
                PageProcessDto viewModel = _mapper.Map<PageProcessDto>(processes);
                return Ok(viewModel);
            });

            return cacheEntry;

        }


        [HttpPost]
        public IActionResult Post([FromBody] Process process)
        {
            Process processClient = _processService.CreateProcess(process);
            ProcessDto viewModel = _mapper.Map<ProcessDto>(processClient);

            if (viewModel != null) return Ok(viewModel);

            return BadRequest("Duplicate id or could not insert this process.");
        }


        // [HttpPut]
        // public IActionResult Put([FromBody] Process process)
        // {
        //     _processService.EditProcess(process);
        //     var viewModel = _mapper.Map<ProcessDto>(process);
        //     return Ok(viewModel);
        // }


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
