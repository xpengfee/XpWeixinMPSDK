#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Message
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/1/16 14:37:04
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
    public class MessageApi : BaseApi
    {
        public MessageApi(Passport passport)
            : base(passport)
        {
        }

        #region 外部调用

        /// <summary>
        /// 功能：发送文本消息接口
        /// 作者：xupeng
        /// 时间：2014-02-10
        /// </summary>
        /// <param name="message">文本消息内容</param>
        /// <param name="fakeId">微信用户FakeId</param>
        /// <returns></returns>
        public SendMessageResult SendMessage(string message, string fakeId)
        {
            return ApiConnection.Connection(() => SendMessageFunc(message, fakeId)) as SendMessageResult;
        }

        /// <summary>
        /// 功能：发送图文消息接口
        /// 作者：xupeng
        /// 时间：2014-02-10
        /// </summary>
        /// <param name="appMsgId">图文素材编号</param>
        /// <param name="fakeId">微信用户FakeId</param>
        /// <returns></returns>
        public SendMessageResult SendImageTextMessage(string appMsgId, string fakeId)
        {
            return ApiConnection.Connection(() => SendImageTextMessageFunc(appMsgId, fakeId)) as SendMessageResult;
        }

        #endregion


        #region 内部实现
        /// <summary>
        /// 功能：发送文本消息接口
        /// 作者：xupeng
        /// 时间：2014-02-10
        /// </summary>
        /// <param name="message">文本消息内容</param>
        /// <param name="fakeId">微信用户FakeId</param>
        /// <returns></returns>
        private SendMessageResult SendMessageFunc(string message, string fakeId)
        {
            return Utility.Message.SendMessage(_passport.Token, _passport.LoginCookie, message,fakeId);
        }

        /// <summary>
        /// 功能：发送图文消息接口
        /// 作者：xupeng
        /// 时间：2014-02-10
        /// </summary>
        /// <param name="appMsgId">图文素材编号</param>
        /// <param name="fakeId">微信用户FakeId</param>
        /// <returns></returns>
        private SendMessageResult SendImageTextMessageFunc(string appMsgId, string fakeId)
        {
            return Utility.Message.SendImageTextMessage(_passport.Token, _passport.LoginCookie, appMsgId, fakeId);
        }
        #endregion
    }
}