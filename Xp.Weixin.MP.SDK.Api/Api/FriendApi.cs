#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Friend
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/1/16 14:36:51
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

namespace Xp.Weixin.MP.SDK.Api
{
    public class FriendApi : BaseApi
    {
        public FriendApi(Passport passport)
            : base(passport)
        {
        }

        #region 外部调用

        /// <summary>
        /// 功能：获取微信用户组列表
        /// 作者：xupeng
        /// 时间：2014-01-16
        /// </summary>
        /// <returns></returns>
        public GroupsResult GetGroups()
        {
            return ApiConnection.Connection(GetGroupsFunc) as GroupsResult;
        }

        /// <summary>
        /// 功能：获取微信用户列表
        /// 作者：xupeng
        /// 时间：2014-01-16
        /// </summary>
        /// <returns></returns>
        public FriendsResult GetFriends()
        {
            return ApiConnection.Connection(GetFriendsFunc) as FriendsResult;
        }

        /// <summary>
        /// 功能：获取微信用户详细信息
        /// 作者：xupeng
        /// 时间：2014-01-16
        /// </summary>
        /// <returns></returns>
        public FriendsDetailResult GetFriendsDetail(long[] fakeIds)
        {
            return ApiConnection.Connection(() => GetFriendsDetailFunc(fakeIds)) as FriendsDetailResult;
        }

        /// <summary>
        /// 功能：获取微信用户头像
        /// 作者：xupeng
        /// 时间：2014-01-16
        /// </summary>
        /// <returns></returns>
        public FriendHeadImageResult GetFriendHeadImage(long fakeId)
        {
            return ApiConnection.Connection(() => GetFriendHeadImageFunc(fakeId)) as FriendHeadImageResult;
        }

        /// <summary>
        /// 功能：获取微信用户详细信息
        /// 作者：xupeng
        /// 时间：2014-03-28
        /// </summary>
        /// <returns></returns>
        public FriendsDetailResult GetFriendsDetail(string[] openids)
        {
            return ApiConnection.Connection(() => GetFriendsDetailFunc(openids)) as FriendsDetailResult;
        }

        /// <summary>
        /// 功能：查询最近的用户的对话信息，找出fakeid
        /// 作者：xupeng
        /// 时间：2014-04-10
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public FindFakeidResult FindFakeid(string keyword)
        {
            return ApiConnection.Connection(() => FindFakeidFunc(keyword)) as FindFakeidResult;
        }

        /// <summary>
        /// 功能：批量查询最近的用户的对话信息，找出fakeid
        /// 作者：xupeng
        /// 时间：2014-04-11
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public FindFakeidsResult FindFakeids(string[] keywords, int range = 80)
        {
            return ApiConnection.Connection(() => FindFakeidsFunc(keywords, range)) as FindFakeidsResult;
        }
        #endregion

        #region 内部实现
        /// <summary>
        /// 功能：获取微信用户组列表
        /// 作者：xupeng
        /// 时间：2014-01-16
        /// </summary>
        /// <returns></returns>
        private GroupsResult GetGroupsFunc()
        {
            return Utility.Friend.GetGroup(_passport.Token, _passport.LoginCookie);
        }

        /// <summary>
        /// 功能：获取微信用户列表
        /// 作者：xupeng
        /// 时间：2014-01-16
        /// </summary>
        /// <returns></returns>
        private FriendsResult GetFriendsFunc()
        {
            return Utility.Friend.GetFriends(_passport.Token, _passport.LoginCookie);
        }

        /// <summary>
        /// 功能：获取微信用户详细信息
        /// 作者：xupeng
        /// 时间：2014-01-16
        /// </summary>
        /// <returns></returns>
        private FriendsDetailResult GetFriendsDetailFunc(long[] fakeIds)
        {
            return Utility.Friend.GetFriendsDetail(_passport.Token, _passport.LoginCookie, fakeIds);
        }


        /// <summary>
        /// 功能：获取微信用户头像
        /// 作者：xupeng
        /// 时间：2014-01-16
        /// </summary>
        /// <returns></returns>
        private FriendHeadImageResult GetFriendHeadImageFunc(long fakeId)
        {
            return Utility.Friend.GetFriendHeadImage(_passport.Token, _passport.LoginCookie, fakeId);
        }

        /// <summary>
        /// 功能：获取微信用户详细信息
        /// 作者：xupeng
        /// 时间：2014-03-28
        /// </summary>
        /// <returns></returns>
        private FriendsDetailResult GetFriendsDetailFunc(string[] openids)
        {
            return Utility.Friend.GetFriendsDetail(_passport.Token, _passport.LoginCookie, openids);
        }

        /// <summary>
        /// 功能：查询最近的用户的对话信息，找出fakeid
        /// 作者：xupeng
        /// 时间：2014-04-10
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        private FindFakeidResult FindFakeidFunc(string keyword)
        {
            return Utility.Friend.FindFakeId(_passport.Token, _passport.LoginCookie, keyword);
        }

        /// <summary>
        /// 功能：批量查询最近的用户的对话信息，找出fakeid
        /// 作者：xupeng
        /// 时间：2014-04-11
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        private FindFakeidsResult FindFakeidsFunc(string[] keywords, int range = 80)
        {
            return Utility.Friend.FindFakeIds(_passport.Token, _passport.LoginCookie, keywords, range);
        }
        #endregion
    }
}