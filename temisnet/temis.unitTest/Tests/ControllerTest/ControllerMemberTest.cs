using Moq;
using NUnit.Framework;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
using temis.Api.v1.Controllers;
using Microsoft.AspNetCore.Mvc;
using temis.unitTest.Tests.Settings.Seeds;
using AutoMapper;
using temis.unitTest.Settings;

namespace temis.unitTest
{
    public class ControllerMemberTest
    {
        Mock<IMemberService> _service;
        public MemberController _controller;
        IMapper _mapper;


        [SetUp]
        public void Setup()
        {
            _service = new Mock<IMemberService>();
            _mapper = MapperMock.Create();
            _controller = new MemberController(_service.Object, _mapper);
        }

        [Test]
        public void GetByIdNoContent()
        {
            _service.Setup(a => a.FindById(It.IsAny<long>())).Returns((Member)null);
            var result = _controller.GetById(It.IsAny<long>());

            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<Member>), result);
            Assert.IsInstanceOf(typeof(NoContentResult), result.Result);

        }

        [Test]
        public void GetByIdReturnOk()
        {
            _service.Setup(a => a.FindById(It.IsAny<long>())).Returns(MemberSeed.GetById());

            var result = _controller.GetById(It.IsAny<long>());
            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<Member>), result);
            Assert.AreEqual(((Member)okResult.Value).Id, MemberSeed.GetById().Id);

        }

        [Test]
        public void CreateMemberReturnOk()
        {
            _service.Setup(s => s.CreateMember(It.IsAny<Member>())).Returns(MemberSeed.Post());

            var result = _controller.Post(It.IsAny<Member>());
            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<Member>), result);
            Assert.AreEqual(((Member)okResult.Value).Id, MemberSeed.Post().Id);
        }

        [Test]
        public void CreateMemberNoContent()
        {
            _service.Setup(s => s.CreateMember(It.IsAny<Member>())).Returns((Member)null);

            var result = _controller.Post(It.IsAny<Member>());

            Assert.IsInstanceOf(typeof(ActionResult<Member>), result);
            Assert.IsInstanceOf(typeof(NoContentResult), result.Result);
        }

        [Test]
        public void EditMember()
        {
            _service.Setup(a => a.EditPassword(It.IsAny<long>(), It.IsAny<string>()));
            var result = _controller.Patch(MemberSeed.Patch());

            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<Member>), result);
            Assert.IsInstanceOf(typeof(NoContentResult), result.Result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteNotFound()
        {
            _service.Setup(a => a.FindById(It.IsAny<long>())).Returns((Member)null);

            var result = _controller.Delete(It.IsAny<long>());
            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf(typeof(NotFoundObjectResult), result.Result);
        }

        [Test]
        public void DeleteSucess()
        {
            _service.Setup(a => a.FindById(It.IsAny<long>())).Returns(MemberSeed.GetById());

            var result = _controller.Delete(It.IsAny<long>()).Result;
            OkObjectResult okResult = result as OkObjectResult;

            Assert.IsInstanceOf(typeof(NoContentResult), result);

        }

        [Test]
        public void GetAllReturnPageResponse()
        {
            var pageResponse = MemberSeed.PageResponseMemberSerice();
            _service.Setup(a => a.Filter(It.IsAny<string>(), It.IsAny<PageRequest>())).Returns(pageResponse);
            
            var result = _controller.GetAll(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>());
            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<Member>), result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllReturnFindAll()
        {
            var pageResponse = MemberSeed.PageResponseMember();
            _service.Setup(a => a.Filter(It.IsAny<string>(), It.IsAny<PageRequest>())).Returns(pageResponse);
            
            var result = _controller.GetAll(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>());
            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.AreEqual(pageResponse.Content.Count, 0);
            Assert.IsInstanceOf(typeof(ActionResult<Member>), result);
            Assert.IsNotNull(result);

        }

    }
}