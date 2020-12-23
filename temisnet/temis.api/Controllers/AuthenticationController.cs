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
    [Route("/api/login")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IMemberService _memberService;

        
        public AuthenticationController(IMemberService memberService)
        {
           _memberService = memberService; 
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="Cpf"></param>
        /// <param name="Password"></param>
        [HttpPost]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Member member)
        {
            var user = _memberService.Validate(member.Cpf, member.Password);

            if (user == null) return NotFound(new { message = "CPF or password is invalid" });
            var token = "";
            await Task.Run(() => token = SecurityService.GenerateToken(user));

            if (token == null) return Unauthorized("We were unable to generate your token");

            return new
            {
                name = user.Name,
                role = user.Role,
                createToken = (DateTime.Today).ToString(),
                token = token
            };

        }

    }
}
