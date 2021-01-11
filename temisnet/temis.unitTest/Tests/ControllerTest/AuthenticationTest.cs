using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using temis.Api.Controllers;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
using temis.unitTest.Tests.Settings.Seeds;

namespace temis.unitTest.Tests.ControllerTest
{
    public class AuthenticationTest
    {
        Mock<IMemberService> _service;
        public AuthenticationController _controller;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IMemberService>();
            _controller = new AuthenticationController(_service.Object);
        }

        [Test]
        public void AuthenticateReturnOk()
        {
            _service.Setup(a => a.Validate(It.IsAny<string>(), It.IsAny<string>())).Returns(MemberSeed.GetById());
            var result = _controller.Authenticate(It.IsAny<string>(), It.IsAny<string>());

            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<Member>), result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void AuthenticateReturnNotFound()
        {
            _service.Setup(a => a.Validate(It.IsAny<string>(), It.IsAny<string>())).Returns((Member)null);
            var result = _controller.Authenticate(It.IsAny<string>(), It.IsAny<string>());

            Assert.IsInstanceOf(typeof(NotFoundObjectResult), result.Result);

        }

    }
}