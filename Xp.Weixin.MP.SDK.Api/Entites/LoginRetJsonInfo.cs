using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Xp.Weixin.MP.Common;

namespace Xp.Weixin.MP.SDK.Api
{
    public class LoginResult : Result<LoginResultData>
    {
    }


    public class LoginResultData : ResultData, IResultData
    {
        public Passport PassPort { get; set; }
        public LoginJsonResultData LoginJsonResult { get; set; }
    }

    /// <summary>
    /// 模拟登录结果json实体
    /// </summary>
    public class LoginJsonResultData
    {
        public BaseResp base_resp { get; set; }
        public string redirect_url { get; set; }
    }


    /// <summary>
    /// 获取当前登录用户信息Json实体
    /// </summary>
    public class LogUserJsonInfo : IResultData
    {
        public string t { get; set; }
        public string ticket { get; set; }
        public string lang { get; set; }
        public string param { get; set; }
        public string uin { get; set; }
        public string user_name { get; set; }
        public string time { get; set; }
    }

}
