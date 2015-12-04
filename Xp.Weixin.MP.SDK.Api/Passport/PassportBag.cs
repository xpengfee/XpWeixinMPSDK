using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Xp.Weixin.MP.Common;

namespace Xp.Weixin.MP.SDK.Api
{
    public class PassportBag
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Passport Passport { get; set; }

        public PassportBag(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
