#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Friend
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2015/3/18 9:52:01
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

using Xp.Weixin.MP.SDK.Api;

namespace Xp.Weixin.MP.SDK.XpProvider
{
    public class Friend : IFriend
    {
        /// <summary>
        /// 功能：获取微信用户组列表
        /// 作者：xupeng
        /// 时间：2014-03-18
        /// </summary>
        /// <returns></returns>
        public Common.GroupsResult GetGroups(string appKey, string appSecret)
        {
            return SdkManager.GetApiContainer(appKey, appSecret).FriendApi.GetGroups();
        }

        /// <summary>
        /// 功能：获取微信用户列表
        /// 作者：xupeng
        /// 时间：2014-03-18
        /// </summary>
        /// <returns></returns>
        public Common.FriendsResult GetFriends(string appKey, string appSecret)
        {
            return SdkManager.GetApiContainer(appKey, appSecret).FriendApi.GetFriends();
        }

        /// <summary>
        /// 功能：获取微信用户详细信息
        /// 作者：xupeng
        /// 时间：2014-03-18
        /// </summary>
        /// <returns></returns>
        public Common.FriendsDetailResult GetFriendsDetail(string appKey, string appSecret, long[] fakeids)
        {
            return SdkManager.GetApiContainer(appKey, appSecret).FriendApi.GetFriendsDetail(fakeids);
        }

        /// <summary>
        /// 功能：获取微信用户头像
        /// 作者：xupeng
        /// 时间：2014-02-18
        /// </summary>
        /// <returns></returns>
        public Common.FriendHeadImageResult GetFriendHeadImage(string appKey, string appSecret, long fakeId)
        {
            return SdkManager.GetApiContainer(appKey, appSecret).FriendApi.GetFriendHeadImage(fakeId);
        }

        /// <summary>
        /// 功能：查询最近的用户的对话信息，找出fakeid
        /// 作者：xupeng
        /// 时间：2014-04-10
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public Common.FindFakeidResult FindFakeid(string appKey, string appSecret, string keyword)
        {
            return SdkManager.GetApiContainer(appKey, appSecret).FriendApi.FindFakeid(keyword);
        }

        /// <summary>
        /// 功能：批量查询最近的用户的对话信息，找出fakeid
        /// 作者：xupeng
        /// 时间：2014-04-11
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public Common.FindFakeidsResult FindFakeids(string appKey, string appSecret, string[] keywords, int range = 80)
        {
            return SdkManager.GetApiContainer(appKey, appSecret).FriendApi.FindFakeids(keywords,range);
        }
    }
}