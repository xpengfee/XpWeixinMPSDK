#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Media
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2015/3/18 12:08:14
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
    public class Media:IMedia
    {
        /// <summary>
        /// 功能：上传图片素材信息接口
        /// 作者：xupeng
        /// 时间：2014-04-10
        /// </summary>
        /// <param name="fileSrc"></param>
        /// <returns></returns>
        public Common.UploadFileResult UploadFile(string appKey, string appSecret, string fileSrc)
        {
            return SdkManager.GetApiContainer(appKey, appSecret).MediaApi.UploadFile(fileSrc);
        }

        /// <summary>
        /// 功能：上传图文素材信息接口
        /// 作者：xupeng
        /// 时间：2014-03-18
        /// </summary>
        /// <param name="articleList"></param>
        /// <returns></returns>
        public Common.OrginNewsResult OrginNews(string appKey, string appSecret, List<Article> articleList)
        {
            return SdkManager.GetApiContainer(appKey, appSecret).MediaApi.OrginNews(articleList);
        }

        /// <summary>
        /// 功能：获取微信公众平台图文素材接口
        /// 作者：xupeng
        /// 时间：2014-03-18
        /// </summary>
        /// <returns></returns>
        public Common.AppMsgResult GetAppMsgList(string appKey, string appSecret)
        {
            return SdkManager.GetApiContainer(appKey, appSecret).MediaApi.GetAppMsgList();
        }
    }
}