#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2013 云合畅想科技（北京）有限公司 版权所有。 
//
// 文件名 WeiXinNewList
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2013/10/29 9:49:40
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
    public class AppMsgList
    {
        public string seq { get; set; }
        public string app_id { get; set; }
        public string file_id { get; set; }
        public string title { get; set; }
        public string digest { get; set; }
        public string create_time { get; set; }
        public string content_url { get; set; }

        public List<AppMsgInfo> multi_item { get; set; }

        public string img_url { get; set; }
        public string author { get; set; }

    }
}