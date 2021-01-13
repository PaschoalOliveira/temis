using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using temis.Api.Models.DTO.MemberDto;
using temis.Api.Controllers.Models.Requests;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
namespace temis.Api.v1.Controllers
{
    /// <summary>
    /// MemberController
    /// </summary>
    [ApiController]
    [Route("api/v1/member")]
    [ApiExplorerSettings(GroupName = "v1")]

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
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/v1/member/{id}
        ///     
        /// </remarks>  
        /// <returns>Member</returns>
        /// <parameter name="id">Member id parameter</parameter>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="403">Forbidden. Resource access is denied</response>
        /// <response code="404">Resource not found</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpGet("{id}")]
        //[Authorize(Roles = "Analista")]
        public ActionResult<Member> GetById([FromRoute] long id)
        {
            Member member = _memberService.FindById(id);

            if(member == null)
            {
                return NoContent();
            }

         //  MemberDto memberDto = _mapper.Map<MemberDto>(member);
           return Ok(member);
        }

        /// <summary>
        /// Get all member
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/v1/member/
        ///     
        /// </remarks>  
        /// <returns>Member All</returns>
        /// <parameter name="page">Actual page number</parameter>
        /// <parameter name="limit">Amount of itens per page</parameter>
        /// <parameter name="name">Member name parameter</parameter>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="403">Forbidden. Resource access is denied</response>
        /// <response code="404">Resource not found</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpGet]
        //[Authorize(Roles = "Analista")]
        public ActionResult<PessoaFisica> GetAll(int? page, int? limit, string name = "")
        {
            PageRequest pageRequest = PageRequest.Of(page, limit);
            PageResponse<PessoaFisica> pageResponse = _memberService.Filter(name, pageRequest);

            if(pageResponse.Content.Count != 0)
            {
                return Ok(pageResponse.Content);
            }

            return Ok(_memberService.FindAll());
        }

        /// <summary>
        /// Create member
        /// </summary>  
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/member/
        ///     {
        ///        "name": "Elayne",
        ///        "lastname": "natalia",
        ///        "role": analista,
        ///        "age": 29,
        ///        "cpf": 12345678901
        ///        "password": "12345678902"
        ///     }
        ///
        /// </remarks>
        /// <returns>Member Create</returns>
        /// <parameter name="member">Member data to be persisted</parameter>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="403">Forbidden. Resource access is denied</response>
        /// <response code="404">Resource not found</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpPost]
        //[Authorize(Roles = "Analista")]
        public ActionResult<Member> Post([FromBody] Member member)
        {
            Member userEntity = _memberService.CreateMember(member);
            if (userEntity == null)
            {
                return NoContent();
            }

            return Ok(userEntity);
        }

        /// <summary>
        /// Partially changes the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Patch api/v1/member/
        ///     {
        ///        "id": 1,
        ///        "password": "12345678902"
        ///     }
        ///
        /// </remarks>
        /// <parameter name="request">Request data to be persisted</parameter>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="403">Forbidden. Resource access is denied</response>
        /// <response code="404">Resource not found</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpPatch("edit")]
        //[Authorize(Roles = "Analista")]
        public ActionResult<Member> Patch([FromBody]EditPasswordRequest request)
        {
            _memberService.EditPassword(request.Id, request.Password);
            return NoContent();
        }

        /// <summary>
        /// Member delete.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Delete api/v1/member/{id}
        ///     
        /// </remarks>  
        /// <parameter name="id">Member id parameter</parameter>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="403">Forbidden. Resource access is denied</response>
        /// <response code="404">Resource not found</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Analista")]
        public ActionResult<Member> Delete([FromRoute] long id)
        {
            bool memberNotFound = _memberService.FindById(id) == null;

            if (memberNotFound)
            {
                return NotFound("Member not found");
            }

            _memberService.Delete(id);
            return NoContent();
        }
    }
}
