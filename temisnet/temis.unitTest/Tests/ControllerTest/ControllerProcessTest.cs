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
using temis.unitTest.Settings;
using temis.unitTest.Tests.Settings.Seeds;

namespace temis.unitTest.Tests.ControllerTest
{
    public class ControllerProcessTest
    {
        Mock<IProcessService> _service;
        Mock<IDistributedCache> _cacheRedis;
        public ProcessController _controller;
        IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IProcessService>();
            _cacheRedis = new Mock<IDistributedCache>();
            _mapper = MapperMock.Create();
            _controller = new ProcessController(_service.Object, _mapper, _cacheRedis.Object);
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
            Assert.AreEqual(((ProcessDto)okResult.Value).Number, seed.Number);
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
        public void PatchReturnOk()
        {
            var mockRequest = Mock.Of<ChangeStatusRequest>();
            var seed = ProcessSeed.Patch();

            _service.Setup(s => s.FindById(It.IsAny<long>())).Returns(seed);

            var result = _controller.Patch(mockRequest);

            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<ProcessDto>), result);
            Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
            Assert.AreEqual(((ProcessDto)okResult.Value).Status, seed.Status);
        }

        [Test]
        public void PatchReturnNotFound()
        {
            var mockRequest = Mock.Of<ChangeStatusRequest>();
            var seed = ProcessSeed.Patch();

            _service.Setup(s => s.FindById(It.IsAny<long>())).Returns((Process)null);

            var result = _controller.Patch(mockRequest);

            NotFoundObjectResult okResult = result.Result as NotFoundObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<ProcessDto>), result);
            Assert.IsInstanceOf(typeof(NotFoundObjectResult), result.Result);
        }
        
        [Test]
         public void DeleteReturnNoContent()
        {
            _service.Setup(s => s.FindById(It.IsAny<long>())).Returns(ProcessSeed.Delete);
           
            var result = _controller.Delete(It.IsAny<long>());

            NoContentResult okResult = result.Result as NoContentResult;

            Assert.IsInstanceOf(typeof(ActionResult<Process>), result);
            Assert.IsInstanceOf(typeof(NoContentResult), result.Result);
        }

        [Test]
         public void DeleteReturnNotFound()
        {
            _service.Setup(s => s.FindById(It.IsAny<long>())).Returns((Process)null);

            var result = _controller.Delete(It.IsAny<long>());

            NotFoundObjectResult okResult = result.Result as NotFoundObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<Process>), result);
            Assert.IsInstanceOf(typeof(NotFoundObjectResult), result.Result);
        }
    }
}