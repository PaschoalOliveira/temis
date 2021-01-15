using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using temis.Core.Models;
using temis.Core.Services.Interface;

namespace temiscertificado.Controllers
{
    [ApiController]
    [Route("/api/certificado")]
    public class CertificadoController : ControllerBase
    {
        private readonly IService _service;

        public CertificadoController(IService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<Certificado> GetById([FromRoute] long id)
        {
            return Ok(_service.FindById(id));
        }

        [HttpGet("rabbitProducer")]
        public ActionResult<string> Send(string key, string msg)
        {
            Connection.Send(key, msg);
            return Ok("Enviado ... ");
        }

        
        [HttpGet("consultaCpf/{cpf}")]
        public ActionResult<string> GetByCpf(string cpf)
        {
           var count =  0;
           string result = null;
           Connection.Send("tests", cpf);

            while (count < 5 && result == null)
            {
              result = Connection.Receive("ABC");
               count ++;
            }

            return Ok(result);
        }

        [HttpGet("rabbitConsumer/{key}")]
        public ActionResult<string> Receive(string key)
        {
            string result =  Connection.Receive(key);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<Certificado> GetAll()
        {
            return Ok(_service.FindAll());
        }

        [HttpPost]
        public ActionResult<Certificado> Post([FromBody] Certificado certificado)
        {
            return Ok(_service.Create(certificado));

        }

        [HttpPut]
        public ActionResult<Certificado> Put([FromBody] Certificado certificado)
        {
            return Ok(_service.Update(certificado));
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] long id)
        {
            _service.Delete(id);
            return NoContent();
        }

    }
}
