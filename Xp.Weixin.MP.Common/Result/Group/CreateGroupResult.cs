#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2014 云合畅想科技（北京）有限公司 版权所有。 
//
// 文件名 CreateGroupResult
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/4/21 15:04:06
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------
#endregion
using System;
using System.Text;
using System.Collections.Generic;

namespace YQZT.Weixin.MP.SDK.Common
{
    public class CreateGroupsResult : Result<CreateGroupsResultData>
    {
    }

    public class CreateGroupsResultData : ResultData, IResultData
    {
        public List<GroupData> group { get; set; }

        public CreateGroupsResultData()
        {
            group = new List<GroupData>();
        }
    }
}