using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.unitTest
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            
        }

        
        [Test]
        public void TestMethod1()
        {            
            var mockInfo = new Mock<Member>();
            mockInfo.Setup(membro => membro.Age).Returns(12);

            Member membro = new Member(1,"teste","teste",12,"juiz","01826287523");

            NUnit.Framework.Assert.AreEqual(mockInfo.Object.Age, membro.Age);          
        }       


        [Test]
        public void TestMethod2()
        {            
            var memberService = new Mock<IMemberService>();
                memberService.Setup(p => p.FindAll())
                .Returns(new List<Member>()
                {
                    new Member
                    {
                        Id = 1,
                        Age = 12,
                        Cpf = "01826252352"
                    }
                });

                NUnit.Framework.Assert.True(memberService.Object.FindAll().Count == 1);
        }

        [Test]
        public void ValidaRetornoPorId()
        {            
            Member member = new Member(1,"teste","teste",12,"juiz","01826287523");

            var memberService = new Mock<IMemberService>();
            memberService.Setup(p => p.FindById(1)).Returns(member);

            NUnit.Framework.Assert.True(memberService.Object.FindById(1) == member);

        }

        
   }
}