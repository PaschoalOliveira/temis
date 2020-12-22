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
                        CPF = "01826252352"
                    }
                });

                NUnit.Framework.Assert.True(memberService.Object.FindAll().Count == 1);
        }

        [Test]
        public void ValidaRetornoPorId()
        {            
            Member member = new Member()
            {
                Id = 1,
                Name = "Elayne",
                LastName = "Natalia",
                Age = 29,
                Role = "Coder Trainee",
                CPF = "111111111",

            };

            Member memberNew = new Member()
            {
                Id = 2,
                Name = "Natalia",
                LastName = "Elayne",
                Age = 29,
                Role = "Coder Trainee",
                CPF = "00000000000",

            };

            List<Member> members = new List<Member>();
            members.Add(member);
            members.Add(memberNew);

            var memberService = new Mock<IMemberService>();
            memberService.Setup(p => p.FindById(2)).Returns(member);
            NUnit.Framework.Assert.True(memberService.Object.FindById(2) == member);

        }

        [Test]
        public void ValidaDeletePorId()
        {            
            Member member = new Member()
            {
                Id = 1,
                Name = "Elayne",
                LastName = "Natalia",
                Age = 29,
                Role = "Coder Trainee",
                CPF = "111111111",

            };

            Member memberNew = new Member()
            {
                Id = 2,
                Name = "Natalia",
                LastName = "Elayne",
                Age = 29,
                Role = "Coder Trainee",
                CPF = "00000000000",

            };

            List<Member> members = new List<Member>();
            members.Add(member);
            members.Add(memberNew);

            var memberService = new Mock<IMemberService>();
            memberService.Setup(p => p.Delete(2));
            memberService.Setup(f => f.FindAll())
            .Returns(members);//FindAll()).Returns(members);
            NUnit.Framework.Assert.True(memberService.Object.FindAll().Count == 1);

        }
   }
}