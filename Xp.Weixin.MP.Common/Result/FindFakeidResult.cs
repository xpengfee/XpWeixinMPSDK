#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 FindFakeidResult
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/4/10 16:44:39
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

namespace Xp.Weixin.MP.Common
{
    public class FindFakeidResult : Result<FindFakeidResultData>
    {
    }

    public class FindFakeidResultData : ResultData, IResultData
    {
        public string Fakeid { get; set; }
    }
}