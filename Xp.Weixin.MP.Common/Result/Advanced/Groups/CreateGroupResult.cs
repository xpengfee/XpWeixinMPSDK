using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xp.Weixin.MP.Common
{
    /// <summary>
    /// 创建分组返回结果
    /// </summary>
    public class CreateGroupResult : WxJsonResult
    {
        public GroupsJson_Group group { get; set; }
    }
}
