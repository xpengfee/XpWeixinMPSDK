#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 FriendsResult
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/1/16 10:56:06
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
    public class FriendsResult : Result<FriendsResultData>
    {
    }

    /// <summary>
    /// 用户数据
    /// </summary>
    public class FriendsResultData : ResultData, IResultData
    {
        /// <summary>
        /// 用户信息列表
        /// </summary>
        public List<FriendsJsonData> FriendsJsonDataList { get; set; }
    }

    /// <summary>
    /// 输出在页面中的用户Json信息
    /// </summary>
    public class FriendsJsonData
    {
        public string id { get; set; }
        public string nick_name { get; set; }
        public string remark_name { get; set; }
        public string group_id { get; set; }
    }
}