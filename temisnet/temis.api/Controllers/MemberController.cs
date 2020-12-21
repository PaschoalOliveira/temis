using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using temis.Api.Controllers.Models.Requests;
using temis.Core.DTO;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
namespace temis.Api.Controllers
{
    [ApiController]
    [Route("/api/member")]
    public class MemberController : ControllerBase
    {
        private IMemberService _memberService;
        private IMapper _mapper;

        public MemberController(IMemberService service, IMapper mapper)
        {
            _memberService = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var member = _memberService.FindById(id);
            var viewModel = _mapper.Map<MemberDto>(member);

            return Ok(viewModel);
        }

        [HttpGet]
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
