#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 ErrResult
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/4/21 15:10:41
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
    /// <summary>
    /// 全局错误码类
    /// </summary>
    public class ErrResult
    {
        public string errcode { get; set; }
        public string errmsg { get; set; }
    }
}