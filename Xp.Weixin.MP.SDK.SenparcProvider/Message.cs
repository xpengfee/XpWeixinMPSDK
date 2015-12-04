#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Message
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2015/3/18 12:10:22
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
    public class Message : IMessage
    {
        /// <summary>
        /// 功能：发送文本消息接口
        /// 作者：xupeng
        /// 时间：2014-03-18
        /// </summary>
        /// <param name="message">文本消息内容</param>
        /// <param name="fakeId">微信用户FakeId</param>
        /// <returns></returns>
        public Common.SendMessageResult SendMessage(string appKey, string appSecret, string message, string fakeId)
        {
            Common.SendMessageResult result = new Common.SendMessageResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "发送文本消息异常";

            try
            {
                Senparc.Weixin.MP.P2PSDK.Common.SendMessageResult sendResult = SdkManager.GetApiContainer(appKey, appSecret).MessageApi.SendMessage(long.Parse(fakeId), message);

                if (sendResult != null)
                {
                    if (sendResult.Data != null && sendResult.Data.base_resp != null)
                    {
                        BaseResp baseResp = new BaseResp();
                        baseResp.err_msg = sendResult.Data.base_resp.err_msg;
                        baseResp.ret = sendResult.Data.base_resp.ret;

                        Common.SendMessageResultData data = new Common.SendMessageResultData();
                        data.base_resp = baseResp;

                        result.Data = data;
                        result.Ret = (ResultKind)sendResult.Result;
                        result.ErrorMessage = sendResult.ErrorMessage;
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
        /// 功能：发送图文消息接口
        /// 作者：xupeng
        /// 时间：2014-03-18
        /// </summary>
        /// <param name="appMsgId">图文素材编号</param>
        /// <param name="fakeId">微信用户FakeId</param>
        /// <returns></returns>
        public Common.SendMessageResult SendImageTextMessage(string appKey, string appSecret, string appMsgId, string fakeId)
        {
            Common.SendMessageResult result = new Common.SendMessageResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "发送图文消息异常";

            try
            {
                Senparc.Weixin.MP.P2PSDK.Common.SendMessageResult sendResult = SdkManager.GetApiContainer(appKey, appSecret).MessageApi.SendMessage(long.Parse(fakeId), long.Parse(appMsgId));

                if (sendResult != null)
                {
                    if (sendResult.Data != null && sendResult.Data.base_resp != null)
                    {
                        BaseResp baseResp = new BaseResp();
                        baseResp.err_msg = sendResult.Data.base_resp.err_msg;
                        baseResp.ret = sendResult.Data.base_resp.ret;

                        Common.SendMessageResultData data = new Common.SendMessageResultData();
                        data.base_resp = baseResp;

                        result.Data = data;
                        result.Ret = (ResultKind)sendResult.Result;
                        result.ErrorMessage = sendResult.ErrorMessage;
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