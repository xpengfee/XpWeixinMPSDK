#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 IMessage
//
// 文件功能描述
// 消息管理接口
// 
// 创建标识：xupeng Create at 2014/1/15 15:55:38
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
    public interface IMessage
    {
        /// <summary>
        /// 功能：发送文本消息接口
        /// 作者：xupeng
        /// 时间：2014-01-15
        /// </summary>
        /// <param name="message">文本消息内容</param>
        /// <param name="fakeId">微信用户FakeId</param>
        /// <returns></returns>
        SendMessageResult SendMessage(string appKey,string appSecret,string message, string fakeId);

        /// <summary>
        /// 功能：发送图文消息接口
        /// 作者：xupeng
        /// 时间：2014-01-15
        /// </summary>
        /// <param name="appMsgId">图文素材编号</param>
        /// <param name="fakeId">微信用户FakeId</param>
        /// <returns></returns>
        SendMessageResult SendImageTextMessage(string appKey,string appSecret,string appMsgId, string fakeId);
    }
}