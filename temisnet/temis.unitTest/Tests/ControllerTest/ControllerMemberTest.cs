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

       /*
        [Test]
        public void DeleteMember()
        {
            Member member = new Member(1,"teste","teste",12,"juiz","01826287523","senha");

            _service.Expect(s => s.CreateMember(member)).Returns(member);
            var controller = new MemberController(_service.Object);

            // OkObjectResult okresult = controller.Post(member) as OkObjectResult;
            var okresult = controller.Post(member);

          //  NUnit.Framework.Assert.True(_service.Object.CreateMember(member) == okresult);
            Assert.IsInstanceOf(typeof(ActionResult<Member>), result);
        } */
        
    }
 }