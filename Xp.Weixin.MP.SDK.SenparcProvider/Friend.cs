#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Friend
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/2/10 17:57:09
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
using Xp.Weixin.MP.SDK;

using Senparc.Weixin.MP.P2PSDK;
using Senparc.Weixin.MP.P2PSDK.Common;

namespace Xp.Weixin.MP.SDK.SenparcProvider
{
    public class Friend : IFriend
    {
        /// <summary>
        /// 功能：获取微信用户组列表
        /// 作者：xupeng
        /// 时间：2014-03-17
        /// </summary>
        /// <returns></returns>
        public GroupsResult GetGroups(string appKey, string appSecret)
        {
            GroupsResult result = new GroupsResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "获取微信用户组异常";

            try
            {
                GetGroupsResult groupsResult = SdkManager.GetApiContainer(appKey, appSecret).FriendApi.GetGroupIds();

                if (groupsResult != null)
                {

                    if (groupsResult.Data != null && groupsResult.Data.GroupDataList.Count > 0)
                    {
                        List<Common.GroupData> list = new List<Common.GroupData>();

                        foreach (Senparc.Weixin.MP.P2PSDK.Common.GroupData data in groupsResult.Data.GroupDataList)
                        {
                            Common.GroupData groupData = new Common.GroupData();
                            groupData.cnt = data.cnt;
                            groupData.id = data.id;
                            groupData.name = data.name;

                            list.Add(groupData);
                        }

                        Common.GroupsData groups = new Common.GroupsData();
                        groups.GroupDataList = list;

                        result.Data = groups;
                        result.Ret = (ResultKind)groupsResult.Result;
                        result.ErrorMessage = groupsResult.ErrorMessage;

                    }
                }
            }
            catch (Exception ex)
            {
                result.Ret = ResultKind.执行过程发生异常;
                result.ErrorMessage = ex.ToString();
            }

            return result;
        }

        /// <summary>
        /// 功能：获取微信用户列表
        /// 作者：xupeng
        /// 时间：2014-03-17
        /// </summary>
        /// <returns></returns>
        public FriendsResult GetFriends(string appKey, string appSecret)
        {
            FriendsResult result = new FriendsResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "获取微信用户列表异常";

            try
            {
                GetFriendsResult friendsResult = SdkManager.GetApiContainer(appKey, appSecret).FriendApi.GetFriends(null,10000000);

                if (friendsResult != null)
                {
                    if (friendsResult.Data != null && friendsResult.Data.FriendsJsonDataList.Count > 0)
                    {
                        List<Common.FriendsJsonData> list = new List<Common.FriendsJsonData>();

                        foreach (Senparc.Weixin.MP.P2PSDK.Common.FriendsJsonData data in friendsResult.Data.FriendsJsonDataList)
                        {
                            Common.FriendsJsonData friendData = new Common.FriendsJsonData();
                            friendData.group_id = data.group_id;
                            friendData.id = data.id;
                            friendData.nick_name = data.nick_name;
                            friendData.remark_name = data.remark_name;

                            list.Add(friendData);
                        }

                        Common.FriendsResultData friends = new Common.FriendsResultData();
                        friends.FriendsJsonDataList = list;

                        result.Data = friends;
                        result.Ret = (ResultKind)friendsResult.Result;
                        result.ErrorMessage = friendsResult.ErrorMessage;

                    }
                }
            }
            catch (Exception ex)
            {
                result.Ret = ResultKind.执行过程发生异常;
                result.ErrorMessage = ex.ToString();
            }

            return result;
        }

        /// <summary>
        /// 功能：获取微信用户详细信息
        /// 作者：xupeng
        /// 时间：2014-03-17
        /// </summary>
        /// <returns></returns>
        public FriendsDetailResult GetFriendsDetail(string appKey, string appSecret, long[] fakeids)
        {
            FriendsDetailResult result = new FriendsDetailResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "获取微信用户详细信息异常";

            try
            {
                GetFriendsDetailsResult friendsDetailResult = SdkManager.GetApiContainer(appKey, appSecret).FriendApi.GetFriendsDetails(fakeids);

                if (friendsDetailResult != null)
                {
                    if (friendsDetailResult.Data != null && friendsDetailResult.Data.WeixinUserInfoList.Count > 0)
                    {
                        List<Common.WeixinUserInfoJson> list = new List<Common.WeixinUserInfoJson>();

                        foreach (Senparc.Weixin.MP.P2PSDK.Common.WeixinUserInfoJson data in friendsDetailResult.Data.WeixinUserInfoList)
                        {
                            Common.WeixinUserInfoJson userData = new Common.WeixinUserInfoJson();

                            Common.BaseResp baseResp = new BaseResp();
                            baseResp.err_msg = data.base_resp.err_msg;
                            baseResp.ret = data.base_resp.ret;

                            Common.ContactInfo info = new ContactInfo();
                            info.city = data.contact_info.city;
                            info.country = data.contact_info.country;
                            info.fake_id = data.contact_info.fake_id;
                            info.gender = data.contact_info.gender;
                            info.group_id = data.contact_info.group_id;
                            info.Id = data.contact_info.Id;
                            info.nick_name = data.contact_info.nick_name;
                            info.province = data.contact_info.province;
                            info.remark_name = data.contact_info.remark_name;
                            info.signature = data.contact_info.signature;
                            info.user_name = data.contact_info.user_name;

                            userData.base_resp = baseResp;
                            userData.contact_info = info;

                            list.Add(userData);
                        }

                        Common.FriendsDetailResultData details = new Common.FriendsDetailResultData();
                        details.WeixinUserInfoList = list;

                        result.Data = details;
                        result.Ret = (ResultKind)friendsDetailResult.Result;
                        result.ErrorMessage = friendsDetailResult.ErrorMessage;

                    }
                }
            }
            catch (Exception ex)
            {
                result.Ret = ResultKind.执行过程发生异常;
                result.ErrorMessage = ex.ToString();
            }

            return result;
        }

        /// <summary>
        /// 功能：获取微信用户头像
        /// 作者：xupeng
        /// 时间：2014-02-11
        /// </summary>
        /// <returns></returns>
        public FriendHeadImageResult GetFriendHeadImage(string appKey, string appSecret,long fakeId)
        {
            FriendHeadImageResult result = new FriendHeadImageResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "获取微信用户头像异常";

            try
            {
                GetFriendHeadImageResult headResult = SdkManager.GetApiContainer(appKey, appSecret).FriendApi.GetFriendHeadImage(fakeId);

                if (headResult != null)
                {
                    if (headResult.Data != null && (!string.IsNullOrEmpty(headResult.Data.HeadImageBase64)))
                    {
                        Common.FriendHeadImageResultData  data= new FriendHeadImageResultData();

                        data.HeadImageBase64 = headResult.Data.HeadImageBase64;

                        result.Data = data;
                        result.Ret = (ResultKind)headResult.Result;
                        result.ErrorMessage = headResult.ErrorMessage;

                    }
                }
            }
            catch (Exception ex)
            {
                result.Ret = ResultKind.执行过程发生异常;
                result.ErrorMessage = ex.ToString();
            }

            return result;
        }

        /// <summary>
        /// 功能：查询最近的用户的对话信息，找出fakeid
        /// 作者：xupeng
        /// 时间：2014-04-10
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public FindFakeidResult FindFakeid(string appKey, string appSecret, string keyword)
        {
            FindFakeidResult result = new FindFakeidResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "查找fakeid异常--Senparc不支持该接口";

            return result;
        }

        /// <summary>
        /// 功能：批量查询最近的用户的对话信息，找出fakeid
        /// 作者：xupeng
        /// 时间：2014-04-11
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public FindFakeidsResult FindFakeids(string appKey, string appSecret, string[] keywords,int range=80)
        {
            FindFakeidsResult result = new FindFakeidsResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "批量查找fakeid异常--Senparc不支持该接口";

            return result;
        }
    }
}