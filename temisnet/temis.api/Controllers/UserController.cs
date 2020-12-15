using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using temis.Api.Controllers.Models.Requests;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Api.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService service)
        {
           _userService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.FindAll());
        }

         /// <summary>
        /// Cria um usuário
        /// </summary>
        /// <response code="200">Usuário cadastrado</response>
        /// <response code="500">Erro interno</response>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            
            User userClient = _userService.CreateUser(user);
            if (userClient != null) return Ok(userClient);

            return BadRequest("Duplicate id or could not insert this user.");
        }

         /// <summary>
        /// Altera um usuário cadastrado
        /// </summary>
        /// <response code="200">Alteração feita com sucesso</response>
        /// <response code="500">Erro interno</response>
        [HttpPut]
        public IActionResult  Put([FromBody] User user)
        {
            _userService.EditUser(user);
            return Ok(user);
        }

        /// <summary>
        /// Altera parcialmente o usuário
        /// </summary>
        /// <response code="200">Usuário cadastrado</response>
        /// <response code="500">Erro interno</response>
        [HttpPatch("edit")]
        public IActionResult Patch([FromBody]EditPasswordRequest request)
        {
            _userService.EditPassword(request.Id, request.Password);
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
            bool userNotFound = _userService.FindById(id) == null;
            if(userNotFound)
            {
                return NotFound("User not found");
            }

            _userService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        [Route("/api/teste")]
        public IActionResult Get(int? tamanhoPag, int? qntPag)
        {
            if(tamanhoPag!=null || qntPag!=null)
            {
                
            } 

            return Ok(_userService.FindAll());
        }
    }
}
