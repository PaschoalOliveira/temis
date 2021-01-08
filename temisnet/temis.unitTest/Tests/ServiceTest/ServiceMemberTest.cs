using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
using  temis.Core.Services.Service;
using temis.unitTest.Tests.Settings.Seeds;

namespace temis.unitTest
{
    public class ServiceMemberTest
    {
        Mock<IMemberRepository> _repository;
        private MemberService _memberService;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IMemberRepository>();
            _memberService = new MemberService(_repository.Object);
        }

        [Test]
        public void CreateMemberSucess()
        {            

            _repository.Setup(p => p.CreateMember(It.IsAny<Member>())).Returns(MemberSeed.Post());
            var result = _memberService.CreateMember((It.IsAny<Member>()));

            Assert.AreEqual(result.Id, MemberSeed.Post().Id);
            Assert.IsInstanceOf(typeof(Member), result);
            Assert.IsNotNull(result);

        }

        [Test]
        public void EditMemberSucess()
        {
            _repository.Setup(p => p.EditMember(It.IsAny<Member>())).Returns(MemberSeed.GetById());
            var result = _memberService.EditMember((It.IsAny<Member>()));
           
            Assert.AreEqual(result.Id, MemberSeed.GetById().Id);
            Assert.IsInstanceOf(typeof(Member), result);
            Assert.IsNotNull(result);
        }


        [Test]
        public void FindByIdSucess()
        {            
            
            _repository.Setup(p => p.FindById(It.IsAny<long>())).Returns(MemberSeed.GetById());
            var result = _memberService.FindById(It.IsAny<long>());

            Assert.IsInstanceOf(typeof(Member), result);
            Assert.IsNotNull(result);

        }
        
        [Test]
        public void ValidateSucess()
        {
            _repository.Setup(p => p.Validate(It.IsAny<string>(), It.IsAny<string>())).Returns(MemberSeed.GetById());
            var result = _memberService.Validate(It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(result.Id, MemberSeed.GetById().Id);
            Assert.IsInstanceOf(typeof(Member), result);
            Assert.IsNotNull(result);

        }    

        [Test]
        public void FinalAll()
        {
            _repository.Setup(p => p.FindAll()).Returns(MemberSeed.GetAll());
            var result = _memberService.FindAll();
            
            Assert.AreEqual(result.Count, MemberSeed.GetAll().Count);
            Assert.IsInstanceOf(typeof(List<Member>), result);
            Assert.IsNotNull(result);

        }   
      
   }
}