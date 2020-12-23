using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solutis.Services;
using temis.Api.Controllers.Models.Requests;
using temis.Api.Models.DTO.MemberDto;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
namespace temis.Api.Controllers
{
    /// <summary>
    /// MemberController
    /// </summary>
    [Route("/api/member")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="mapper"></param>
        public MemberController(IMemberService service, IMapper mapper)
        {
           _memberService = service;
           _mapper = mapper;
        }

        /// <summary>
        /// Get member by id number
        /// </summary>
        /// <param name="idMember"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpGet("{id}")]
        [Authorize(Roles = "coder, advogado")]
        public IActionResult Get([FromRoute] long id)
        {
            var member = _memberService.FindById(id);

            return Ok( _mapper.Map<MemberDto>(member));
        }

        /// <summary>
        /// Get all member
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpGet]
        //[Authorize(Roles = "coder, advogado")]
        public IActionResult Get(int? page, int? limit, string name = "")
        {   
            PageRequest pageRequest = PageRequest.Of(page, limit);
            PageResponse<Member> pageResponse = _memberService.Filter(name, pageRequest);

            if (pageResponse.Content != null || pageResponse.Content.Count != 0)
            {
                return Ok(pageResponse.Content);
            } 

            return Ok(_memberService.FindAll());
        }

        /// <summary>
        /// Cria um usuário
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpPost]
        [Authorize(Roles = "")]
        public IActionResult Post([FromBody] Member member)
        {
            Member memberClient = _memberService.CreateMember(member);
            var viewModel = _mapper.Map<MemberDto>(memberClient);
            if (memberClient != null) return Ok(viewModel);

            return BadRequest("Duplicate id or could not insert this member.");
        }

        /// <summary>
        /// Altera um usuário cadastrado
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpPut]
        [Authorize(Roles = "")]
        public IActionResult  Put([FromBody] Member member)
        {
            _memberService.EditMember(member);
            var viewModel = _mapper.Map<MemberDto>(member);
            return Ok(viewModel);
        }

        /// <summary>
        /// Altera parcialmente o usuário
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>
        
        [HttpPatch("edit")]
        [Authorize(Roles = "")]
        public IActionResult Patch([FromBody]EditPasswordRequest request)
        {
            _memberService.EditPassword(request.Id, request.Password);
            return Ok();
        }

        /// <summary>
        /// Judgment delete.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Delete /api/Member/{id}
        ///     
        /// </remarks>  
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpDelete("{id}")]
        [Authorize(Roles = "")]
        public ActionResult Delete([FromRoute] long id)
        {
            bool memberNotFound = _memberService.FindById(id) == null;

            if(memberNotFound)
            {
                return NotFound("Member not found");
            }

            _memberService.Delete(id);
            return NoContent();
        }

    }
}
