#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Friend
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/1/17 10:04:41
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------
#endregion
using System;
using System.Net;
using System.Text;
using System.Collections.Generic;

using Newtonsoft.Json;
using Xp.Weixin.MP.Common;
using System.Collections;
using Xp.Weixin.MP.SDK.Api.CommonAPIs;

namespace Xp.Weixin.MP.SDK.Api.Utility
{
    public class Friend
    {
        /// <summary>
        /// 功能：模拟登录，获取微信用户组具体实现
        /// 作者：xupeng
        /// 时间：2014-01-17
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="cookie">cookie</param>
        /// <returns></returns>
        public static GroupsResult GetGroup(string token, CookieContainer cookie)
        {
            GroupsResult result = new GroupsResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "获取微信用户组异常";


            /*获取用户信息的url，这里有几个参数给大家讲一下，1.token此参数为上面的token 2.pagesize此参数为每一页显示的记录条数
            3.pageid为当前的页数，4.groupid为微信公众平台的用户分组的组id，当然这也是我的猜想不一定正确*/

            string cUrl = "https://mp.weixin.qq.com/cgi-bin/contactmanage?tuser/index&token=" + token + "&lang=zh_CN&pagesize=100000000&pageidx=0&type=0&groupid=0";

            try
            {
                string cResult = Http.Instance.GetPage(cUrl, cUrl, cookie);

                if (cResult.IndexOf("登录超时，请重新") > 0)
                {
                    result.Ret = ResultKind.账户验证失败;
                    result.ErrorMessage = "账户模拟登录失败";
                }
                else
                {
                    string textresult = Tools.GetValue(cResult, "({\"groups\":", "}).groups");
                    List<GroupData> grouplist = JsonConvert.DeserializeObject<List<GroupData>>(textresult);
                    if (grouplist != null && grouplist.Count > 0)
                    {
                        GroupsData data = new GroupsData();
                        data.GroupDataList = grouplist;

                        result.Data = data;
                        result.Ret = ResultKind.成功;
                        result.ErrorMessage = "获取微信用户组成功";
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
        /// 功能：获取微信用户信息
        /// 作者：xupeng
        /// 时间：2014-01-17
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static FriendsResult GetFriends(string token, CookieContainer cookie, int pageSize = 10000000)
        {
            FriendsResult result = new FriendsResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "获取微信用户信息异常";

            /*获取用户信息的url，这里有几个参数给大家讲一下，1.token此参数为上面的token 2.pagesize此参数为每一页显示的记录条数

             3.pageid为当前的页数，4.groupid为微信公众平台的用户分组的组id，当然这也是我的猜想不一定正确*/
            string cUrl = "https://mp.weixin.qq.com/cgi-bin/contactmanage?tuser/index&token=" + token + "&lang=zh_CN&pagesize=" + pageSize + "&pageidx=0&type=0&groupid=0";

            try
            {
                string cResult = Http.Instance.GetPage(cUrl, cUrl, cookie);

                if (cResult.IndexOf("登录超时，请重新") > 0)
                {
                    result.Ret = ResultKind.账户验证失败;
                    result.ErrorMessage = "账户模拟登录失败";
                }
                else
                {
                    string textresult = Tools.GetValue(cResult, "contacts\":", "}).contacts").Replace("friendsList:({\\\"contacts\\\":", "").Replace(" ", "");
                    //string reg = "<script id=\\\"json-friendList\\\" type=\\\"json/text\\\">[^<]*</script>";  
                    ////由于此方法获取过来的信息是一个html网页所以此处使用了正则表达式，注意：（此正则表达式只是获取了fakeid的信息如果想获得一些其他的信息修改此处的正则表达式就可以了。）
                    //Regex r = new Regex(reg); //定义一个Regex对象实例
                    //string textresult1 = text2.Replace("\r\n", "").Replace("\n","").Replace("\\\"","\"").Trim();
                    //mc = r.Matches(textresult);
                    //Int32 friendSum = mc.Count;          //好友总数

                    List<FriendsJsonData> friendsList = JsonConvert.DeserializeObject<List<FriendsJsonData>>(textresult);
                    if (friendsList != null && friendsList.Count > 0)
                    {
                        FriendsResultData data = new FriendsResultData();
                        data.FriendsJsonDataList = friendsList;

                        result.Data = data;
                        result.Ret = ResultKind.成功;
                        result.ErrorMessage = "获取微信用户信息成功";
                    }
                    else
                    {
                        result.Ret = ResultKind.P2PBridge错误;
                        result.ErrorMessage = "未获取到微信用户信息";
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
        /// 时间：2014-01-17
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cookie"></param>
        /// <param name="fakeids"></param>
        /// <returns></returns>
        public static FriendsDetailResult GetFriendsDetail(string token, CookieContainer cookie, long[] fakeids)
        {
            FriendsDetailResult result = new FriendsDetailResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "获取微信用户详细信息异常";

            string cUrl = "https://mp.weixin.qq.com/cgi-bin/getcontactinfo";
            string formDataFormat = "token={0}&lang=zh_CN&f=json&ajax=1&t=ajax-getcontactinfo&fakeid={1}";

            try
            {
                string cResult = string.Empty;

                List<WeixinUserInfoJson> userList = new List<WeixinUserInfoJson>();

                for (int i = 0; i < fakeids.Length; i++)
                {
                    cResult = Http.Instance.Post(cUrl, cUrl, cookie, string.Format(formDataFormat, token, fakeids[i]));

                    if (cResult.IndexOf("登录超时，请重新") > 0||cResult.IndexOf("invalid session") > 0)
                    {
                        result.Ret = ResultKind.账户验证失败;
                        result.ErrorMessage = "账户模拟登录失败";

                        break;
                    }
                    else
                    {
                        WeixinUserInfoJson userInfo = JsonConvert.DeserializeObject<WeixinUserInfoJson>(cResult);

                        if (userInfo.base_resp.ret == 0)
                        {
                            if (userInfo.contact_info != null)
                                userList.Add(userInfo);
                        }
                        else
                        {
                            result.Ret = ResultKind.P2PBridge错误;
                            result.ErrorMessage = userInfo.base_resp.err_msg;

                        }
                    }
                }


                if (userList != null && userList.Count > 0)
                {
                    FriendsDetailResultData data = new FriendsDetailResultData();
                    data.WeixinUserInfoList = userList;

                    result.Data = data;
                    result.Ret = ResultKind.成功;
                    result.ErrorMessage = "获取微信用户详细信息成功";
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("invalid session") > -1)
                {
                    result.Ret = ResultKind.账户验证失败;
                }
                else
                {
                    result.Ret = ResultKind.执行过程发生异常;
                }
                result.ErrorMessage = ex.ToString();
            }

            return result;
        }

        /// <summary>
        /// 功能：获取微信用户头像信息
        /// 作者：xupeng
        /// 时间：2014-02-11
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cookie"></param>
        /// <param name="fakeId"></param>
        /// <returns></returns>
        public static FriendHeadImageResult GetFriendHeadImage(string token, CookieContainer cookie, long fakeId)
        {
            FriendHeadImageResult result = new FriendHeadImageResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "获取微信用户头像信息异常";

            string cUrl = "https://mp.weixin.qq.com/misc/getheadimg?fakeid=" + fakeId + "&token=" + token + "&lang=zh_CN";

            try
            {
                byte[] returnArray = Http.Instance.GetImage(cUrl, null, cookie);

                if (returnArray == null)
                {
                    result.Ret = ResultKind.账户验证失败;
                    result.ErrorMessage = "账户模拟登录失败";
                }
                else
                {

                    string cResult = Convert.ToBase64String(returnArray);

                    if (!string.IsNullOrEmpty(cResult))//判断是否正常获取头像信息
                    {
                        FriendHeadImageResultData data = new FriendHeadImageResultData();
                        data.HeadImageBase64 = cResult;

                        result.Data = data;
                        result.Ret = ResultKind.成功;
                        result.ErrorMessage = "获取微信用户头像信息成功";
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
        /// 时间：2014-03-28
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cookie"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static FriendsDetailResult GetFriendsDetail(string token, CookieContainer cookie, string[] openids)
        {
            FriendsDetailResult result = new FriendsDetailResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "获取微信用户详细信息异常";

            token = "yknAIYfPASWlXT4kPOqRuJ-GxrGZLE_HtUYKuyfW83jJakcoyI0jqB_jeKR76QLtN0E9RzWFIdFG8fR7vf4Js77b2ywUwTnzg4KN8syDwuutQQ7AkIUk9_fcFLSDrIWGfKKPHxCP8X44md5dMOEuzw";
            string cUrl = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}";

            try
            {
                string cResult = string.Empty;

                List<WeixinUserInfoJson> userList = new List<WeixinUserInfoJson>();

                for (int i = 0; i < openids.Length; i++)
                {
                    cResult = Http.Instance.GetPage(string.Format(cUrl, token, openids[i]), "", null);
                    WeixinUserInfoJson userInfo = JsonConvert.DeserializeObject<WeixinUserInfoJson>(cResult);

                    if (userInfo.base_resp.ret == 0)
                    {
                        if (userInfo.contact_info != null)
                            userList.Add(userInfo);
                    }
                    else
                    {
                        result.Ret = ResultKind.P2PBridge错误;
                        result.ErrorMessage = userInfo.base_resp.err_msg;

                        break;
                    }
                }


                if (userList != null && userList.Count > 0)
                {
                    FriendsDetailResultData data = new FriendsDetailResultData();
                    data.WeixinUserInfoList = userList;

                    result.Data = data;
                    result.Ret = ResultKind.成功;
                    result.ErrorMessage = "获取微信用户详细信息成功";
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
        /// 功能：模拟登录，查询最近的用户的对话信息，找出fakeid
        /// 作者：xupeng
        /// 时间：2014-04-10
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="cookie">cookie</param>
        /// <returns></returns>
        public static FindFakeidResult FindFakeId(string token, CookieContainer cookie, string keyword)
        {
            FindFakeidResult result = new FindFakeidResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "获取Fakeid信息失败";

            try
            {

                //1.获取最近的80个用户(轮询服务间隔10分钟运行，期间最多有这些几十个用户)
                FriendsResult friendsResult = GetFriends(token, cookie, 80);

                if (friendsResult.Ret == ResultKind.成功 && friendsResult.Data.FriendsJsonDataList.Count > 0)
                {
                    string cUrlFormat = "https://mp.weixin.qq.com/cgi-bin/singlesendpage?t=message/send&action=index&tofakeid={0}&token={1}&lang=zh_CN";

                    foreach (FriendsJsonData item in friendsResult.Data.FriendsJsonDataList)
                    {
                        string cUrl = string.Format(cUrlFormat, item.id, token);
                        string cResult = Http.Instance.GetPage(cUrl, cUrl, cookie);
                        string textresult = Tools.GetValue(cResult, "wx.cgiData = ", "wx.cgiData.tofakeid =");

                        if (textresult.IndexOf(keyword) > 0)
                        {
                            FindFakeidResultData data = new FindFakeidResultData();
                            data.Fakeid = item.id;

                            result.Data = data;
                            result.Ret = ResultKind.成功;
                            result.ErrorMessage = "获取Fakeid信息成功";

                            break;
                        }
                    }

                }
                else
                {
                    result.Ret = friendsResult.Ret;
                    result.ErrorMessage = friendsResult.ErrorMessage;
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
        /// 功能：模拟登录，批量查询最近的用户的对话信息，找出fakeid
        /// 作者：xupeng
        /// 时间：2014-04-11
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="cookie">cookie</param>
        /// <returns></returns>
        public static FindFakeidsResult FindFakeIds(string token, CookieContainer cookie, string[] keywords, int range = 80)
        {
            FindFakeidsResult result = new FindFakeidsResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "批量获取Fakeid信息失败";

            try
            {
                //.0 FindDataList
                List<KeywordFakeidData> FindDataList = new List<KeywordFakeidData>();

                //1.获取最近的80个用户(轮询服务间隔10分钟运行，期间最多有这些几十个用户)
                FriendsResult friendsResult = GetFriends(token, cookie, range);

                //2.会话记录集合
                Hashtable hashList = new Hashtable();

                //3.是否在线查找
                bool online = true;

                if (friendsResult.Ret == ResultKind.成功 && friendsResult.Data.FriendsJsonDataList.Count > 0)
                {
                    string cUrlFormat = "https://mp.weixin.qq.com/cgi-bin/singlesendpage?t=message/send&action=index&tofakeid={0}&token={1}&lang=zh_CN";

                    foreach (string keyword in keywords)
                    {
                        online = true;

                        if (hashList.Count > 0)
                        {
                            foreach (DictionaryEntry dic in hashList)
                            {
                                if (dic.Value.ToString().IndexOf(keyword) > 0)
                                {
                                    KeywordFakeidData data = new KeywordFakeidData();
                                    data.Fakeid = dic.Key.ToString();
                                    data.Keyword = keyword;

                                    FindDataList.Add(data);

                                    online = false;//已经找到，就不在进行在线查找了
                                    break;
                                }
                            }
                        }

                        if (!online)
                            continue;

                        foreach (FriendsJsonData item in friendsResult.Data.FriendsJsonDataList)
                        {
                            if (hashList.ContainsKey(item.id))
                                continue;

                            string cUrl = string.Format(cUrlFormat, item.id, token);
                            string cResult = Http.Instance.GetPage(cUrl, cUrl, cookie);

                            if (cResult.IndexOf("登录超时，请重新") > 0)
                            {
                                break;
                            }
                            else
                            {
                                string textresult = Tools.GetValue(cResult, "wx.cgiData = ", "wx.cgiData.tofakeid =");

                                hashList.Add(item.id, textresult);

                                if (textresult.IndexOf(keyword) > 0)
                                {
                                    KeywordFakeidData data = new KeywordFakeidData();
                                    data.Fakeid = item.id;
                                    data.Keyword = keyword;

                                    FindDataList.Add(data);

                                    break;
                                }
                            }
                        }
                    }

                    if (FindDataList.Count > 0)
                    {
                        FindFakeidsResultData data = new FindFakeidsResultData();
                        data.FindDataList = FindDataList;

                        result.Data = data;
                        result.Ret = ResultKind.成功;
                        result.ErrorMessage = "批量获取Fakeid信息成功";
                    }
                    else
                    {
                        result.Ret = ResultKind.P2PBridge错误;
                        result.ErrorMessage = "未获取到Fakeid信息";
                    }
                }
                else
                {
                    result.Ret = friendsResult.Ret;
                    result.ErrorMessage = friendsResult.ErrorMessage;
                }

            }
            catch (Exception ex)
            {
                result.Ret = ResultKind.执行过程发生异常;
                result.ErrorMessage = ex.ToString();
            }

            return result;
        }
    }
}