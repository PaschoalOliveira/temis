using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using temis.Api.Controllers.Models.Requests;
using temis.Api.Models.DTO;
using temis.Api.Models.ViewModel;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Api.v1.Controllers
{
    /// <summary>
    /// JudgmentController
    /// </summary>
    [ApiController]
    [Route("/api/v1/judgment")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class JudgmentController : ControllerBase
    {
        private readonly IJudgmentService _judgmentService;
        private IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public JudgmentController(IJudgmentService service, IMapper mapper)
        {
            _judgmentService = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns judgment.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/judgment/{id}
        ///     
        /// </remarks>  
        /// <returns>Search Results</returns>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpGet("{id}")]
        public ActionResult<JudgmentViewModel> Get([FromRoute] long id)
        {

            var judgment = _judgmentService.FindById(id);
            // var viewModel = _mapper.Map<JudgmentDto>(judgment);
            //  return Ok(viewModel);

            return Ok(_mapper.Map<JudgmentViewModel>(judgment));
          
        }

        /// <summary>
        /// Returns all judgment.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/judgment
        ///     
        /// </remarks>  
        /// <returns>Search Results</returns>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpGet]
        public ActionResult<Judgment> Get(int? page, int? limit)
        {

            PageRequest pReq = PageRequest.Of(page, limit);
            PageResponse<Judgment> judgments = _judgmentService.FindAll(pReq);
            return Ok(judgments.Content);
        }

        /// <summary>
        /// Returns create judgment.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/judgment
        ///     
        /// </remarks>  
        /// <returns>Search Results</returns>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>
        [HttpPost]
        public IActionResult Post([FromBody] JudgmentDto judgment)
        {

            // Judgment judgmentClient = _judgmentService.CreateJudgment(judgment);
            //  var viewModel = _mapper.Map<JudgmentDto>(judgmentClient);
            //   if (viewModel != null) return Ok(viewModel);
            //  return BadRequest("Duplicate id or could not insert this judgment.");

            var judgmentEntity = _judgmentService.CreateJudgment(_mapper.Map<Judgment>(judgment));
            return Ok(_mapper.Map<JudgmentViewModel>(judgmentEntity));

        }

        /// <summary>
        /// Returns judgment edit.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/judgment
        ///     
        /// </remarks>  
        /// <returns>Search Results</returns>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpPut]
        public IActionResult Put([FromBody] JudgmentDto judgment)
        {
            //_judgmentService.EditJudgment(judgment);
            //var viewModel = _mapper.Map<JudgmentDto>(judgment);
            //return Ok(judgment);

            var judgmentEntity = _judgmentService.EditJudgment(_mapper.Map<Judgment>(judgment));
            return Ok(_mapper.Map<JudgmentViewModel>(judgmentEntity));
        }

        /// <summary>
        /// Judgment delete.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Delete /api/judgment/{id}
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
