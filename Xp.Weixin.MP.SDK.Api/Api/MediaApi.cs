#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Media
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/1/16 14:07:54
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
    public class MediaApi : BaseApi
    {
        public MediaApi(Passport passport)
            : base(passport)
        {
        }

        #region 外部调用
        /// <summary>
        /// 功能：上传图片素材信息接口
        /// 作者：xupeng
        /// 时间：2014-04-10
        /// </summary>
        /// <param name="fileSrc"></param>
        /// <returns></returns>
        public UploadFileResult UploadFile(string fileSrc)
        {
            return ApiConnection.Connection(() => UploadFileFunc(fileSrc)) as UploadFileResult;
        }

        /// <summary>
        /// 功能：上传图文素材信息接口
        /// 作者：xupeng
        /// 时间：2014-02-10
        /// </summary>
        /// <param name="articleList"></param>
        /// <returns></returns>
        public OrginNewsResult OrginNews(List<Article> articleList)
        {
            return ApiConnection.Connection(() => OrginNewsFunc(articleList)) as OrginNewsResult;
        }

        /// <summary>
        /// 功能：获取微信公众平台图文素材接口
        /// 作者：xupeng
        /// 时间：2014-02-10
        /// </summary>
        /// <returns></returns>
        public AppMsgResult GetAppMsgList()
        {
            return ApiConnection.Connection(GetAppMsgListFunc) as AppMsgResult;
        }
        #endregion

        #region 内部实现

        /// <summary>
        /// 功能：上传图片素材信息接口
        /// 作者：xupeng
        /// 时间：2014-04-10
        /// </summary>
        /// <param name="fileSrc"></param>
        /// <returns></returns>
        private UploadFileResult UploadFileFunc(string fileSrc)
        {
            return Utility.Media.UploadFile(_passport.Token, _passport.LoginCookie, _passport.UserName, _passport.Ticket, fileSrc);
        }

        /// <summary>
        /// 功能：上传图文素材信息接口
        /// 作者：xupeng
        /// 时间：2014-02-10
        /// </summary>
        /// <param name="articleList"></param>
        /// <returns></returns>
        private OrginNewsResult OrginNewsFunc(List<Article> articleList)
        {
            return Utility.Media.OrginNews(_passport.Token, _passport.LoginCookie, _passport.UserName, _passport.Ticket, articleList);
        }

        /// <summary>
        /// 功能：获取微信公众平台图文素材接口
        /// 作者：xupeng
        /// 时间：2014-02-10
        /// </summary>
        /// <returns></returns>
        private AppMsgResult GetAppMsgListFunc()
        {
            return Utility.Media.GetAppMsgList(_passport.Token, _passport.LoginCookie);
        }

       
        #endregion
    }
}