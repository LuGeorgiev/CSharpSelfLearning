using EstateManagment.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;

namespace EstateManagment.Services.Tests.Mocks
{
    public class UserManagerMock
    {
        public static Mock<UserManager<User>> New
            => new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), 
                //Mock.Of<IOptions<IdentityOptions>>(),
                null,null,null,null, null, null, null, null);
    }
}
