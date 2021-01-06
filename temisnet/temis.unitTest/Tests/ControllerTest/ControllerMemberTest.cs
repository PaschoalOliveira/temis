using Moq;
using NUnit.Framework;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
using temis.Api.v1.Controllers;
using Microsoft.AspNetCore.Mvc;
using temis.unitTest.Tests.Settings.Seeds;
using AutoMapper;

namespace temis.unitTest
{
    public class ControllerMemberTest
     {

        Mock<IMemberService> _service;
        
        public MemberController _controller;

        public IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IMemberService>();
            _controller = new MemberController(_service.Object, _mapper);
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
                
    }
 }