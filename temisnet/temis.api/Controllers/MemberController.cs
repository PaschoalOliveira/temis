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
        private IMemberService _memberService;
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
        [HttpGet("{id}")]
        [Authorize(Roles = "coder, advogado")]
        public IActionResult Get([FromRoute] long id)
        {
            var member = _memberService.FindById(id);

            return Ok( _mapper.Map<MemberDto>(member));
        }

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
        /// <response code="200">Usuário cadastrado</response>
        /// <response code="500">Erro interno</response>
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
        /// <response code="200">Alteração feita com sucesso</response>
        /// <response code="500">Erro interno</response>
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
        /// <response code="200">Usuário cadastrado</response>
        /// <response code="500">Erro interno</response>
        [HttpPatch("edit")]
        [Authorize(Roles = "")]
        public IActionResult Patch([FromBody]EditPasswordRequest request)
        {
            _memberService.EditPassword(request.Id, request.Password);
            return Ok();
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <response code="200">Deleta um usuário cadastrado</response>
        /// <response code="500">Erro interno</response>
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
