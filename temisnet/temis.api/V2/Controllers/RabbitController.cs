using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using temis.api.rabbit;
using temis.Core.Services.Interfaces;

namespace temis.api.V2.Controllers 
{
    [ApiController]
    [Route("/api/v2/rabbit")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ExcludeFromCodeCoverageAttribute]
    public class RabbitController : ControllerBase
    {
        private IProcessService _processService;

        public RabbitController(IProcessService service)
        {
            _processService = service;
        }

        [HttpGet("rabbitProducer/")]
        public void RabbitProducer()
        {
            RabbitService.enviarMensagem();
        }


        [HttpGet("rabbitConsumer/")]
        public IActionResult RaRabbitConsumer()
        {
            string mensagem = RabbitService.consumirMensagem();
            return Ok(mensagem);
        }

        [HttpGet("consultaCpf")]
        public ActionResult<string> GetByCpf()
        {
           
           string result = RabbitService.consumirMensagem();

           bool resultProcess = _processService.FindByCpf(result);

          // RabbitService.enviarMensagem(); 

            return Ok(resultProcess);
        }

    }
}