#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Message
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2015/3/18 13:56:43
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
            return SdkManager.GetApiContainer(appKey, appSecret).MessageApi.SendMessage(message, fakeId);
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
            return SdkManager.GetApiContainer(appKey, appSecret).MessageApi.SendImageTextMessage(appMsgId, fakeId);
        }
    }
}