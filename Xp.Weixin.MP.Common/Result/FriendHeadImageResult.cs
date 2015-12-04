#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 FriendHeadImageResult
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/1/16 11:28:11
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
    public class FriendHeadImageResult : Result<FriendHeadImageResultData>
    {
    }

    /// <summary>
    /// 用户数据
    /// </summary>
    public class FriendHeadImageResultData : ResultData, IResultData
    {
        /// <summary>
        /// 储存头像信息Base64编码
        /// </summary>
        public string HeadImageBase64 { get; set; }
    }
}