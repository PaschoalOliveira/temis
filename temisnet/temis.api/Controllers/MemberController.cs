using Microsoft.AspNetCore.Mvc;
using temis.Api.Controllers.Models.Requests;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
namespace temis.Api.Controllers
{
    [ApiController]
    [Route("/api/member")]
    public class MemberController : ControllerBase
    {
        private IMemberService _memberService;

        public MemberController(IMemberService service)
        {
           _memberService = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var member = _memberService.FindById(id);

            return Ok(member);
        }

        [HttpGet]
        public IActionResult Get(int? page, int? limit, string name)
        {   
            PageRequest pageRequest = PageRequest.Of(page, limit);
            PageResponse<Member> pageResponse = _memberService.Filter(name, pageRequest);

            if (pageResponse.Content != null || pageResponse.Content.Count != 0)
            {
                return Ok(pageResponse);
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
            if (memberClient != null) return Ok(memberClient);

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
            return Ok(member);
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
