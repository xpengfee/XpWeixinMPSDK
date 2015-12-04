#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 FriendsDetailResult
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/1/16 11:01:29
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
    public class FriendsDetailResult : Result<FriendsDetailResultData>
    {
    }

    /// <summary>
    /// 用户数据
    /// </summary>
    public class FriendsDetailResultData : ResultData, IResultData
    {
        /// <summary>
        /// 用户信息列表
        /// </summary>
        public List<WeixinUserInfoJson> WeixinUserInfoList { get; set; }
    }

    /// <summary>
    /// 通过Ajax获取的用户信息（JSON格式）
    /// </summary>
    public class WeixinUserInfoJson : IResultData
    {
        public BaseResp base_resp { get; set; }
        public ContactInfo contact_info { get; set; }
        //public List<GroupData> groups { get; set; }
    }

    /// <summary>
    /// 用户详细信息
    /// </summary>
    public class ContactInfo
    {
        /// <summary>
        /// 此Id为数据库主键，非微信信息
        /// </summary>
        public int Id { get; set; }

        public long? fake_id { get; set; }
        public string nick_name { get; set; }
        public string user_name { get; set; }
        public string signature { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        /// <summary>
        /// 性别。男：1，女：2
        /// </summary>
        public string gender { get; set; }
        public string remark_name { get; set; }
        public int group_id { get; set; }

        //"fake_id":13221445,"nick_name":"苏震巍",
        //"user_name":"JeffreySu","signature":"",
        //"city":"苏州","province":"江苏","country":"中国",
        //"gender":1,"remark_name":"","group_id":0
    }
}