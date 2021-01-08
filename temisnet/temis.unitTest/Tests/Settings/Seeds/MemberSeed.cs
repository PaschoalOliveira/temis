using System.Collections.Generic;
using temis.Api.Controllers.Models.Requests;
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
                Id = 7
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
    }
}