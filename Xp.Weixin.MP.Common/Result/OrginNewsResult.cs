#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 OrginNewsResult
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/2/10 17:49:18
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
    public class OrginNewsResult : Result<OrginNewsResultData>
    {
    }

    public class OrginNewsResultData : ResultData, IResultData
    {
        public OrginNewsJsonData orginNewsJson { get; set; }

        public OrginNewsResultData()
        {
            orginNewsJson = new OrginNewsJsonData();
        }
    }

    public class OrginNewsJsonData
    {
        public int ret { get; set; }
        public string msg { get; set; }
    }
}