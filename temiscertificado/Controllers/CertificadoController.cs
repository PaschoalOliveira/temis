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
