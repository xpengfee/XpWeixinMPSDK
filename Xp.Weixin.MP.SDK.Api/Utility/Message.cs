#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Message
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/3/13 17:24:41
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
using Xp.Weixin.MP.SDK.Api.CommonAPIs;

namespace Xp.Weixin.MP.SDK.Api.Utility
{
    public class Message
    {
        /// <summary>
        /// 功能：发送文本信息
        /// 作者：xupeng
        /// 时间：2014-03-13
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cookie"></param>
        /// <param name="message">文本信息</param>
        /// <param name="fakeId">FakeId</param>
        /// <returns></returns>
        public static SendMessageResult SendMessage(string token, CookieContainer cookie, string message, string fakeId)
        {
            SendMessageResult result = new SendMessageResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "发送文本信息异常";

            string strMsg = System.Web.HttpUtility.UrlEncode(message);  //对传递过来的信息进行url编码
            string paydata = "type=1&content=" + strMsg + "&error=false&imgcode=&tofakeid=" + fakeId + "&token=" + token + "&ajax=1";
            string cUrl = "https://mp.weixin.qq.com/cgi-bin/singlesend?t=ajax-response&lang=zh_CN";
            string cReferer = "https://mp.weixin.qq.com/cgi-bin/singlesendpage?tofakeid=" + fakeId + "&t=message/send&action=index&token=" + token + "&lang=zh_CN";

            try
            {
                string cResult = Http.Instance.Post(cUrl, cReferer, cookie, paydata);

                if (cResult.IndexOf("登录超时，请重新") > 0)
                {
                    result.Ret = ResultKind.账户验证失败;
                    result.ErrorMessage = "账户模拟登录失败";
                }
                else
                {
                    string textresult = Tools.GetValue(cResult, "{\"base_resp\":", "}") + "}";

                    BaseResp baseResp = JsonConvert.DeserializeObject<BaseResp>(textresult);
                    if (baseResp != null)
                    {
                        SendMessageResultData data = new SendMessageResultData();
                        data.base_resp = baseResp;

                        if (baseResp.ret == 0)
                        {
                            result.Data = data;
                            result.Ret = ResultKind.成功;
                            result.ErrorMessage = "发送文本信息成功";
                        }
                        else
                        {
                            result.Ret = ResultKind.发送消息失败;
                            result.ErrorMessage = baseResp.err_msg;
                        }
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
        /// 功能：发送图文信息
        /// 作者：xupeng
        /// 时间：2014-03-17
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cookie"></param>
        /// <param name="appMsgId">图文素材编号</param>
        /// <param name="fakeId">FakeId</param>
        /// <returns></returns>
        public static SendMessageResult SendImageTextMessage(string token, CookieContainer cookie, string appMsgId, string fakeId)
        {
            SendMessageResult result = new SendMessageResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "发送图文信息异常";

            string paydata = "type=10&fid=" + appMsgId + "&appmsgid=" + appMsgId + "&error=false&tofakeid=" + fakeId + "&token=" + token + "&ajax=1&content=&imagecode=";
            string cUrl = "https://mp.weixin.qq.com/cgi-bin/singlesend?t=ajax-response&lang=zh_CN";
            string cReferer = "https://mp.weixin.qq.com/cgi-bin/singlesendpage?tofakeid=" + fakeId + "&t=message/send&action=index&token=" + token + "&lang=zh_CN";

            try
            {
                string cResult = Http.Instance.Post(cUrl, cReferer, cookie, paydata);

                if (cResult.IndexOf("登录超时，请重新") > 0)
                {
                    result.Ret = ResultKind.账户验证失败;
                    result.ErrorMessage = "账户模拟登录失败";
                }
                else
                {
                    string textresult = Tools.GetValue(cResult, "{\"base_resp\":", "}") + "}";

                    BaseResp baseResp = JsonConvert.DeserializeObject<BaseResp>(textresult);
                    if (baseResp != null)
                    {
                        SendMessageResultData data = new SendMessageResultData();
                        data.base_resp = baseResp;

                        if (baseResp.ret == 0)
                        {
                            result.Data = data;
                            result.Ret = ResultKind.成功;
                            result.ErrorMessage = "发送图文信息成功";
                        }
                        else
                        {
                            result.Ret = ResultKind.发送消息失败;
                            result.ErrorMessage = baseResp.err_msg;
                        }
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

    }
}