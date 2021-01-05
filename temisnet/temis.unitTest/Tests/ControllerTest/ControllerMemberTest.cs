using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
using temis.Core.Services.Service;
using temis.Api.v1.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace temis.unitTest
 {
     public class ControllerMemberTest
     {

        Mock<IMemberService> _service;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IMemberService>();
        }

        [Test]
        public void CreateMember()
        {
            Member member = new Member(1,"teste","teste",12,"juiz","01826287523","senha");

            _service.Setup(s => s.CreateMember(member)).Returns(member);
            var controller = new MemberController(_service.Object);

            var result = controller.Post(member);
            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf(typeof(ActionResult<Member>), result);
            Assert.AreEqual(((Member)okResult.Value).Id, member.Id);
        }
        
    }
 }