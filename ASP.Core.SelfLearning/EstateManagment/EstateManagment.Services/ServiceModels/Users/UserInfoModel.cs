using System;
using System.Collections.Generic;
using System.Text;

namespace EstateManagment.Services.ServiceModels.Users
{
    public class UserInfoModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
