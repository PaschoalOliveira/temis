using System.Collections.Generic;
using temis.Core.Models;

namespace temis.unitTest.Tests.Settings.Seeds
{
    public class MemberSeed
    {
        public static Member Post()
        {
            return new Member()
            {
                Id = 6
            };
        }

        public static Member GetById()
        {
            return new Member()
            {
                Id = 7,
                Age = 29
            };
        }

    }
}