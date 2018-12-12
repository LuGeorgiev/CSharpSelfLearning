using System.Collections.Generic;

namespace EstateManagment.Services.Models.Users
{
    public class UserInfoModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
