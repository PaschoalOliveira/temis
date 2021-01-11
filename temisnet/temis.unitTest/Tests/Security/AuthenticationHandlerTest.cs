using NUnit.Framework;
using temis.Api.Security;
using temis.unitTest.Tests.Settings.Seeds;

namespace temis.unitTest
{
    public class AuthenticationHandlerTest
    { 
        
        [Test]
        public void CreateToken()
        {  
            var token = AuthenticationHandler.CreateToken(MemberSeed.GetById());
            Assert.IsNotNull(token);

        }

    }
}