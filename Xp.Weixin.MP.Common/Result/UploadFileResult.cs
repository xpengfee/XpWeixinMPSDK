#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 UploadFileResult
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/4/10 15:51:28
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

namespace Xp.Weixin.MP.Common
{
    public class UploadFileResult : Result<UploadFileResultData>
    {
    }

    public class UploadFileResultData : ResultData, IResultData
    {
        public UploadFileJsonData uploadFileJson { get; set; }

        public UploadFileResultData()
        {
            uploadFileJson = new UploadFileJsonData();
        }
    }

    public class UploadFileJsonData
    {
        public BaseResp base_resp { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public string content { get; set; }
    }
}