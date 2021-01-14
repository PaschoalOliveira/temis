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

        Mock<IMemberRepository> mockMemberRepository;
        private IMemberService _memberService;

        [SetUp]
        public void Setup()
        {
            mockMemberRepository = new Mock<IMemberRepository>();
            _memberService = new MemberService(mockMemberRepository.Object);
        }

        [Test]
        public void Create()
        {            
            // Arrange
            Member seed = MemberSeed.MemberSerice();
            mockMemberRepository.Setup(a => a.Create(It.IsAny<Member>())).Returns(seed);

            // Act
            var result = _memberService.CreateMember(It.IsAny<Member>());

            // Assert
            mockMemberRepository.Verify(a => a.Create(It.IsAny<Member>()), Times.Once);
            Assert.IsInstanceOf(typeof(Member), result);
            Assert.AreEqual(seed, result);
        }

        [Test]
        public void Update()
        {
            // Arrange
            Member seed = MemberSeed.MemberSerice();
            mockMemberRepository.Setup(a => a.Update(It.IsAny<Member>())).Returns(seed);

            // Act
            var result = _memberService.EditMember(It.IsAny<Member>());

            // Assert
            mockMemberRepository.Verify(a => a.Update(It.IsAny<Member>()), Times.Once);
            Assert.IsInstanceOf(typeof(Member), result);
            Assert.AreEqual(seed, result);
        }

        [Test]
        public void FindAll()
        {
            // Arrange
            List<Member> seed = MemberSeed.ListMemberSerice();
            mockMemberRepository.Setup(a => a.FindAll()).Returns(seed);

            // Act
            var result = _memberService.FindAll();

            // Assert
            mockMemberRepository.Verify(a => a.FindAll(), Times.Once);
            Assert.IsInstanceOf(typeof(List<Member>), result);
            Assert.AreEqual(seed, result);
        }


        [Test]
        public void FindById()
        {
            // Arrange
            Member seed = MemberSeed.MemberSerice();
            mockMemberRepository.Setup(a => a.FindById(It.IsAny<long>())).Returns(seed);

            // Act
            var result = _memberService.FindById(It.IsAny<long>());

            // Assert
            mockMemberRepository.Verify(a => a.FindById(It.IsAny<long>()), Times.Once);
            Assert.IsInstanceOf(typeof(Member), result);
            Assert.AreEqual(seed, result);
        }
        
        [Test]
        public void Validate()
        {
            // Arrange
            Member seed = MemberSeed.MemberSerice();
            mockMemberRepository.Setup(a => a.Validate(It.IsAny<string>(), It.IsAny<string>())).Returns(seed);

            // Act
            var result = _memberService.Validate(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            mockMemberRepository.Verify(a => a.Validate(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            Assert.IsInstanceOf(typeof(Member), result);
            Assert.AreEqual(seed, result);
        }

        [Test]
        public void EditPassword()
        {
            // Arrange         
            Member seed = MemberSeed.MemberSerice();   
            mockMemberRepository.Setup(a => a.FindById(It.IsAny<long>())).Returns(seed);
            mockMemberRepository.Setup(a => a.EditPassword(It.IsAny<long>(), It.IsAny<string>()));

            // Act
            _memberService.EditPassword(It.IsAny<long>(), It.IsAny<string>());

            // Assert
            mockMemberRepository.Verify(a => a.EditPassword(It.IsAny<long>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Delete()
        {
            // Arrange         
            Member seed = MemberSeed.MemberSerice();   
            mockMemberRepository.Setup(a => a.FindById(It.IsAny<long>())).Returns(seed);
            mockMemberRepository.Setup(a => a.Delete(It.IsAny<long>()));

            // Act
            _memberService.Delete(It.IsAny<long>());

            // Assert
            mockMemberRepository.Verify(a => a.Delete(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void Filter()
        {
            // Arrange
            PageResponse<Member> seed = MemberSeed.PageResponseMemberSerice();
            mockMemberRepository.Setup(a => a.Filter(It.IsAny<string>(), It.IsAny<PageRequest>())).Returns(seed);

            // Act
            var result = _memberService.Filter(It.IsAny<string>(), It.IsAny<PageRequest>());

            // Assert
            mockMemberRepository.Verify(a => a.Filter(It.IsAny<string>(), It.IsAny<PageRequest>()), Times.Once);
            Assert.IsInstanceOf(typeof(PageResponse<Member>), result);
            Assert.AreEqual(seed, result);
        }
      
   }
}