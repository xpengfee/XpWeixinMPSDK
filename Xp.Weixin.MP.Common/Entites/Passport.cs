#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Passport
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/1/16 14:18:28
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

namespace Xp.Weixin.MP.Common
{
    /// <summary>
    /// 通行证
    /// </summary>
    public class Passport
    {
        /// <summary>
        /// 登录后得到的令牌
        /// </summary>        
        public string Token { get; set; }
        /// <summary>
        /// 登录后得到的cookie
        /// </summary>
        public CookieContainer LoginCookie { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Ticket(redis ticket)
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// 用户名|AppId
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码|AppSecret
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 供服务器记录唯一标准（备用）
        /// </summary>
        public int WeixinAppId { get; set; }
    }
}
