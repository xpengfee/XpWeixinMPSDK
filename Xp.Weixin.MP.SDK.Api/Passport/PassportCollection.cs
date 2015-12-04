using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Xp.Weixin.MP.SDK.Api
{
    /// <summary>
    /// 同时管理多个应用的Passport的容器
    /// </summary>
    public class PassportCollection : Dictionary<string, PassportBag>
    {
        /// <summary>
        /// 统一URL前缀
        /// </summary>
        public string BasicUrl { get; set; }
        public string MarketingToolUrl { get; set; }
        public PassportCollection()
        {
        }
    }
}
