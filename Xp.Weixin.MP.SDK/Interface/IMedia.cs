#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 IMaterial
//
// 文件功能描述
// 素材管理接口
// 
// 创建标识：xupeng Create at 2014/1/15 16:11:51
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
    public interface IMedia
    {
        /// <summary>
        /// 功能：上传图片素材信息接口
        /// 作者：xupeng
        /// 时间：2014-04-10
        /// </summary>
        /// <param name="fileSrc"></param>
        /// <returns></returns>
        UploadFileResult UploadFile(string appKey, string appSecret, string fileSrc);

        /// <summary>
        /// 功能：上传图文素材信息接口
        /// 作者：xupeng
        /// 时间：2014-01-15
        /// </summary>
        /// <param name="articleList"></param>
        /// <returns></returns>
        OrginNewsResult OrginNews(string appKey,string appSecret,List<Article> articleList);

        /// <summary>
        /// 功能：获取微信公众平台图文素材接口
        /// 作者：xupeng
        /// 时间：2014-01-15
        /// </summary>
        /// <returns></returns>
        AppMsgResult GetAppMsgList(string appKey, string appSecret);
    }
}