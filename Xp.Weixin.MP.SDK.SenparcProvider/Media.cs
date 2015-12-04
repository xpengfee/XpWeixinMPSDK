#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Media
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2015/3/18 11:48:00
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
    public class Media:IMedia
    {
        /// <summary>
        /// 功能：上传图片素材信息接口
        /// 作者：xupeng
        /// 时间：2014-04-10
        /// </summary>
        /// <param name="fileSrc"></param>
        /// <returns></returns>
        public UploadFileResult UploadFile(string appKey, string appSecret, string fileSrc)
        {
            UploadFileResult result = new UploadFileResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "上传图片信息异常--Senparc不支持该接口";

            return result;
        }

        /// <summary>
        /// 功能：上传图文素材信息接口
        /// 作者：xupeng
        /// 时间：2014-03-18
        /// </summary>
        /// <param name="articleList"></param>
        /// <returns></returns>
        public OrginNewsResult OrginNews(string appKey, string appSecret, List<Article> articleList)
        {
            OrginNewsResult result = new OrginNewsResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "上传图文素材信息异常--Senparc不支持该接口";

            //try
            //{
            //    SendMessageNewsResult sendResult = SdkManager.GetApiContainer(appKey, appSecret).MessageApi.SendMessage("",articleList);

            //    if (sendResult != null)
            //    {

            //        if (sendResult.Data != null && sendResult.Data.GroupDataList.Count > 0)
            //        {
            //            List<Common.GroupData> list = new List<Common.GroupData>();

            //            foreach (Senparc.Weixin.MP.P2PSDK.Common.GroupData data in sendResult.Data.GroupDataList)
            //            {
            //                Common.GroupData groupData = new Common.GroupData();
            //                groupData.cnt = data.cnt;
            //                groupData.id = data.id;
            //                groupData.name = data.name;

            //                list.Add(groupData);
            //            }

            //            Common.GroupsData groups = new Common.GroupsData();
            //            groups.GroupDataList = list;

            //            result.Data = groups;
            //            result.Ret = (ResultKind)sendResult.Result;
            //            result.ErrorMessage = sendResult.ErrorMessage;

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    result.Ret = ResultKind.执行过程发生异常;
            //    result.ErrorMessage = ex.ToString();
            //}

            return result;
        }

        /// <summary>
        /// 功能：获取微信公众平台图文素材接口
        /// 作者：xupeng
        /// 时间：2014-03-18
        /// </summary>
        /// <returns></returns>
        public AppMsgResult GetAppMsgList(string appKey, string appSecret)
        {
            AppMsgResult result = new AppMsgResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "获取微信公众平台图文素材异常--Senparc不支持该接口";

            return result;
        }
    }
}