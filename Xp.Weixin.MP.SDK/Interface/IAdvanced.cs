#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 IAdvanced
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/4/22 10:47:12
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

using Xp.Weixin.MP.Common;

namespace Xp.Weixin.MP.SDK.Interface
{
    /// <summary>
    /// 高级接口
    /// </summary>
    public interface IAdvanced
    {
        GroupsResult GetGroups(string appKey, string appSecret);
    }
}