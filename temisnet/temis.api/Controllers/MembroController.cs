using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using temis.api.Models;

namespace temis.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembroController : ControllerBase
    {
        private static List<Membro> Membros = new List<Membro>()
        {
            new Membro(){ 
                MembroId = 1, 
                Nome="joao" 
            },
            new Membro(){ MembroId = 2, Nome="fabiano" 
            }
        };

        public MembroController()
        {

        }

        [HttpGet]
        public IEnumerable<Membro> Get()
        {
            return Membros.ToArray();
        }
        
        [HttpGet("{id}")]
        [Produces("application/json","application/xml")]
        public ActionResult<Membro> Get(int id)
        {
            var membro = Membros.FirstOrDefault(membro =>membro.MembroId.Equals(id));

            if(membro == null)
                return BadRequest("Não encontrado");
            
            return Ok(membro);
        }

        /*
        [HttpGet("{nome}")]
        public IActionResult GetNome(string nome)
        {
            var membro = Membros.FirstOrDefault(membro =>membro.Nome.Contains(nome));
            if(membro == null)
                return BadRequest("Não encontrado");  
            return Ok(membro);
        }
        */
    }
}
