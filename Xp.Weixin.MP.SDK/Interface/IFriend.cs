#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 IFriend
//
// 文件功能描述
// 用户信息接口
// 
// 创建标识：xupeng Create at 2014/1/15 15:56:39
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

namespace Xp.Weixin.MP.SDK
{
    public interface IFriend
    {
        /// <summary>
        /// 功能：获取微信用户组列表
        /// 作者：xupeng
        /// 时间：2014-01-16
        /// </summary>
        /// <returns></returns>
        GroupsResult GetGroups(string appKey,string appSecret);

        /// <summary>
        /// 功能：获取微信用户列表
        /// 作者：xupeng
        /// 时间：2014-01-16
        /// </summary>
        /// <returns></returns>
        FriendsResult GetFriends(string appKey, string appSecret);

        /// <summary>
        /// 功能：获取微信用户详细信息
        /// 作者：xupeng
        /// 时间：2014-01-16
        /// </summary>
        /// <returns></returns>
        FriendsDetailResult GetFriendsDetail(string appKey, string appSecret,long[] fakeids);


        /// <summary>
        /// 功能：获取微信用户头像
        /// 作者：xupeng
        /// 时间：2014-01-16
        /// </summary>
        /// <returns></returns>
        FriendHeadImageResult GetFriendHeadImage(string appKey, string appSecret, long fakeId);

        /// <summary>
        /// 功能：查询最近的用户的对话信息，找出fakeid
        /// 作者：xupeng
        /// 时间：2014-04-11
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        FindFakeidResult FindFakeid(string appKey, string appSecret, string keyword);

        /// <summary>
        /// 功能：批量查询最近的用户的对话信息，找出fakeid
        /// 作者：xupeng
        /// 时间：2014-04-11
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        FindFakeidsResult FindFakeids(string appKey, string appSecret, string[] keywords,int range=80);
    }
}