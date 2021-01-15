using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using temis.api.rabbit;

namespace temis.api.V2.Controllers
{
    [ApiController]
    [Route("/api/v2/rabbit")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ExcludeFromCodeCoverageAttribute]
    public class RabbitController
    {
        [HttpGet("rabbitProducer/")]
        public void RabbitProducer()
        {
            RabbitService rabbitService = new RabbitService();
            rabbitService.enviarMensagem();
        }


        [HttpGet("rabbitConsumer/")]
        public String RaRabbitConsumer()
        {
            RabbitService rabbitService = new RabbitService();
            string mensagem = rabbitService.consumirMensagem();
            return mensagem;
        }
    }
}