using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xp.Weixin.MP.Common;
using Xp.Weixin.MP.SDK.Api.CommonAPIs;
using Xp.Weixin.MP.SDK.Api.HttpUtility;

namespace Xp.Weixin.MP.SDK.Api.AdvancedAPIs
{
    /// <summary>
    /// 二维码创建返回结果
    /// </summary>
    public class CreateQrCodeResult : WxJsonResult
    {
        public string ticket { get; set; }
        public int expire_seconds { get; set; }
    }
}
