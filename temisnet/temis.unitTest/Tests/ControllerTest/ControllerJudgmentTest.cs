using Moq;
using NUnit.Framework;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
using temis.Api.v1.Controllers;
using Microsoft.AspNetCore.Mvc;
using temis.unitTest.Tests.Settings.Seeds;
using AutoMapper;
using temis.Api.Models.DTO;
using temis.Api.Models.ViewModel;
using System.Collections.Generic;

namespace temis.unitTest
{
    public class ControllerJudgmentTest
     {

        Mock<IJudgmentService> _service;
        Mock<IMapper> _mapper;
        
        public JudgmentController _controller;


        [SetUp]
        public void Setup()
        {
            _service = new Mock<IJudgmentService>();
            _mapper = new Mock<IMapper>(); 
            _controller = new JudgmentController(_service.Object, _mapper.Object);
        }

        [Test]
        public void GetReturnOk()
        {
            _service.Setup(x => x.FindAll(It.IsAny<PageRequest>())).Returns(JudgmentSeed.Get());
            var result = _controller.Get(1,3);
            OkObjectResult okResult = result.Result as OkObjectResult;

            // Assert.IsInstanceOf(typeof(ActionResult<PageResponseDto<JudgmentViewModel>>), result);
            Assert.AreEqual(((List<Judgment>)okResult.Value)[0].Veredict, JudgmentSeed.Get().Content[0].Veredict);
        }   

        // [Test]
        public void GetByIdReturnOk()
        {
            _service.Setup(x => x.FindById(It.IsAny<long>())).Returns(JudgmentSeed.GetById());

            var result = _controller.Get(2);
            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.AreEqual(((JudgmentViewModel)okResult.Value).Veredict, JudgmentSeed.GetById().Veredict);
        }

        [Test]
        public void DeleteReturnNotFound()
        {
            _service.Setup(x => x.FindById(It.IsAny<long>())).Returns((Judgment)null);
            
            var result = _controller.Delete(1);

            Assert.IsInstanceOf(typeof(NotFoundObjectResult), result);
        }

        [Test]
        public void DeleteReturnNoContent()
        {
            _service.Setup(x => x.FindById(It.IsAny<long>())).Returns(JudgmentSeed.Delete());
            
            var result = _controller.Delete(2);

            Assert.IsInstanceOf(typeof(NoContentResult), result);
        }

        // [Test]
        public void PostReturnOk()
        {
            _service.Setup(x => x.CreateJudgment(It.IsAny<Judgment>())).Returns(JudgmentSeed.Post());

            var result = _controller.Post(JudgmentSeed.PostDto());
            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.AreEqual(((JudgmentViewModel)okResult.Value).Veredict,JudgmentSeed.Post().Veredict);
        }

        // [Test]
        public void PutReturnOk()
        {
            _service.Setup(x => x.EditJudgment(It.IsAny<Judgment>())).Returns(JudgmentSeed.Put());

            var result = _controller.Put(JudgmentSeed.PutDto());
            OkObjectResult okResult = result.Result as OkObjectResult;

            Assert.AreEqual(((JudgmentViewModel)okResult.Value).Veredict, JudgmentSeed.PutDto().Veredict);
        }
    }
 }