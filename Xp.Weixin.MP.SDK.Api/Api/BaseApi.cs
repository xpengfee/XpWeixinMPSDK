using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Xp.Weixin.MP.Common;

namespace Xp.Weixin.MP.SDK.Api
{
    /// <summary>
    /// API调用类基类
    /// </summary>
    public class BaseApi
    {
        protected Passport _passport;
        protected ApiConnection ApiConnection { get; set; }

        public BaseApi(Passport passport)
        {
            _passport = passport;
            ApiConnection = new ApiConnection(passport);
        }
    }
}
