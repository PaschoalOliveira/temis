using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
using  temis.Core.Services.Service;


namespace temis.unitTest
{
    public class ServiceTest
    {

        Mock<IMemberService> mockMemberService;
        private IMemberService _userService;

        [SetUp]
        public void Setup()
        {
            mockMemberService = new Mock<IMemberService>();
        }

        [Test]
        public void ValidaRetornoPorId()
        {            
            Member member = new Member(1,"teste","teste",12,"juiz","01826287523","senha");

            mockMemberService.Setup(p => p.FindById(1)).Returns(member);

            NUnit.Framework.Assert.True(mockMemberService.Object.FindById(1) == member);

        }

        [Test]
        public void ValidaRetornoAllMember()
        {
                mockMemberService.Setup(p => p.FindAll())
                .Returns(new List<Member>()
                {
                    new Member
                    {
                        Id = 1,
                        Age = 12,
                        Cpf = "01826252352"
                    }
                });
                
                NUnit.Framework.Assert.True(mockMemberService.Object.FindAll().Count == 1);

        }

        [Test]
        public void ValidaInserirMember()
        {
           
            Member member = new Member(1,"teste","teste",12,"juiz","01826287523","senha");

            mockMemberService.Setup(p => p.CreateMember(member)).Returns(member);
            NUnit.Framework.Assert.True(mockMemberService.Object.CreateMember(member) == member);

        }

        [Test]
        public void ValidaEditMember() // duvidas
        {
        
            Member member = new Member(2,"teste","service",12,"juiz","01826287523","senha");

            mockMemberService.Setup(p => p.EditMember(member)).Returns(member);
            NUnit.Framework.Assert.True(mockMemberService.Object.EditMember(member) == member); 

        }

        [Test]
        public void ValidaSenha()
        {
           
            Member member = new Member(1,"teste","teste",12,"role","cpf", "password");

            var cpf = "cpf";
            var password = "password";

            mockMemberService.Setup(p => p.Validate(cpf,password)).Returns(member);
            NUnit.Framework.Assert.True(mockMemberService.Object.Validate(member.Cpf,member.Password) == member);

        }

        
      
        
   }
}