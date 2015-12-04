#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 SendMessageResult
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/2/10 17:37:25
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
    public class SendMessageResult : Result<SendMessageResultData>
    {
    }

    public class SendMessageResultData : ResultData, IResultData
    {
        public BaseResp base_resp { get; set; }

        public SendMessageResultData()
        {
            base_resp = new BaseResp();
        }
    }
}