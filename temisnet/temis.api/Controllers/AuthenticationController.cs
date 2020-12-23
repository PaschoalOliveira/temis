using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using temis.Api.Security;
using temis.Core.Services.Interfaces;
namespace temis.Api.Controllers
{
    /// <summary>
    /// AuthenticationController
    /// </summary>
    [Route("/api/login")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMemberService _memberService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="memberService"></param>
        public AuthenticationController(IMemberService memberService)
        {
           _memberService = memberService; 
        }

        /// <param name="Cpf"></param>
        /// <param name="Password"></param>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(string Cpf, string Password) // https://localhost:5001/api/login/?Cpf=111111111&Password=teste
        {
            var user = _memberService.Validate(Cpf, Password);

            if (user == null) return NotFound(new { message = "CPF or password is invalid" });
            var token = "";
            await Task.Run(() => token = AuthenticationHandler.CreateToken(user));

            if (token == null) return Unauthorized("We were unable to generate your token");

            return new
            {
                name = user.Name,
                role = user.Role,
                createToken = (DateTime.Now).ToString(),
                validToken = (DateTime.Now).AddHours(1).ToString(),
                token = token
            };

        }

    }
}
