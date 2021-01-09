using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using NUnit.Framework;
using temis.api.Requests;
using temis.Api.Controllers.Models.Requests;
using temis.Api.Models.DTO;
using temis.Api.v1.Controllers;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
using temis.unitTest.Tests.Settings.Seeds;

namespace temis.unitTest.Tests.ControllerTest
{
    public class ControllerProcessTest
    {
        Mock<IProcessService> _service;
        Mock<IDistributedCache> _cacheRedis;
        public ProcessController _controller;
        Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IProcessService>();
            _cacheRedis = new Mock<IDistributedCache>();
            _mapper = new Mock<IMapper>();
            _controller = new ProcessController(_service.Object, _mapper.Object, _cacheRedis.Object);
        }

        [Test]
        public void Get()
        {
            var seed = ProcessSeed.Get();

            _service.Setup(s => s.FindAll(It.IsAny<string>(), It.IsAny<PageRequest>())).Returns(seed);

            var result = _controller.Get(It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<string>());

            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<Process>), result);
        }

        [Test]
        public void PostReturnOK()
        {
            var seed = ProcessSeed.Post();

            _service.Setup(s => s.CreateProcess(It.IsAny<Process>())).Returns(seed);

            var result = _controller.Post(It.IsAny<CreateProcessRequest>());

            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<Process>), result);
            Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
            //Assert.AreEqual(result.Value.Number, seed.Number);
            //Assert.AreEqual(((Process)okResult.Value).Number, seed.Number);
        }

        [Test]
        public void PostReturnNoContent()
        {
            _service.Setup(s => s.CreateProcess(It.IsAny<Process>())).Returns((Process)null);

            var result = _controller.Post(It.IsAny<CreateProcessRequest>());

            NoContentResult noContentResult = result.Result as NoContentResult;

            Assert.IsInstanceOf(typeof(ActionResult<Process>), result);
            Assert.IsInstanceOf(typeof(NoContentResult), result.Result);
        }

        [Test]
        //Erro no FindById, como se ele recebesse nulo
        //Falta fazer o teste de Retorno NotFound.
        public void PatchReturnOk()
        {
            var seed = ProcessSeed.Patch();

            _service.Setup(s => s.FindById(It.IsAny<long>())).Returns(seed);
            _service.Setup(s => s.ChangeStatus(It.IsAny<Process>())).Returns(seed);

            var result = _controller.Patch(It.IsAny<ChangeStatusRequest>());

            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<Process>), result);
            Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
        }
        
        [Test]
         public void DeleteReturnNoContent()
        {
            _service.Setup(s => s.FindById(It.IsAny<long>())).Returns(ProcessSeed.Delete);
            _service.Setup(s => s.Delete(It.IsAny<long>()));

            var result = _controller.Delete(It.IsAny<long>());

            NoContentResult okResult = result.Result as NoContentResult;

            Assert.IsInstanceOf(typeof(ActionResult<Process>), result);
            Assert.IsInstanceOf(typeof(NoContentResult), result.Result);
        }
    }
}