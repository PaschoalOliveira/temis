using System.Collections.Generic;
using temis.Api.Controllers.Models.Requests;
using temis.Api.Models.DTO.MemberDto;
using temis.Core.Models;

namespace temis.unitTest.Tests.Settings.Seeds
{
    public class MemberSeed
    {
        public static Member Post()
        {
            return new Member()
            {
                Id = 6,
                Age = 29
            };
        }

        public static Member GetById()
        {
            return new Member()
            {
                Id = 7,
                Cpf= "111111",
                Role = "analista"
            };
        }

        
        public static EditPasswordRequest Patch()
        {
            return new EditPasswordRequest()
            {
                Id = 8,
                Password = "teste"
            };
        }
        public static List<Member> GetAll()
        {
            return new List<Member>()
            {
                new Member() 
                {
                    Id = 9,
                    Age = 30
                },
                new Member()
                {
                    Id = 10,
                    Age = 29
                }
            };
        }

        public static Member MemberSerice()
        {
            return new Member()
            {
                Id = 67
            };
        }
        public static List<Member> ListMemberSerice()
        {
            return new List<Member> 
            {
                new Member
                {
                    Id = 756
                }
            };
        }
        public static PageResponse<Member> PageResponseMemberSerice()
        {
            return new PageResponse<Member>()
            {
                Content = new List<Member> 
                {
                    new Member
                    {
                        Id = 1238
                    }
                }
            };
        }

        public static PageResponse<Member> PageResponseMember()
        {
            return new PageResponse<Member>()
            {
                Content = new List<Member> 
                {
                }
            };
        }
    }
}