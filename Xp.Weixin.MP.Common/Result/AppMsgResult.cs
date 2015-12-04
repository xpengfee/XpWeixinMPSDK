#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2013 云合畅想科技（北京）有限公司 版权所有。 
//
// 文件名 WeiXinNew
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2013/10/29 9:47:22
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
    public class AppMsgResult : Result<AppMsgData>
    {
    }

    public class AppMsgData : ResultData, IResultData
    {
        public List<AppMsgList> item { get; set; }
        public AppMsgCnt file_cnt { get; set; }
    }

    public class AppMsgCnt
    {
        public int total { get; set; }
        public int img_cnt { get; set; }
        public int voice_cnt { get; set; }
        public int video_cnt { get; set; }
        public int app_msg_cnt { get; set; }
        public int commondity_msg_cnt { get; set; }
    }
}