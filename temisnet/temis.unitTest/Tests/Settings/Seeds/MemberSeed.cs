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
    }
}