#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 FindFakeidResult
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/4/10 16:44:39
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
    public class FindFakeidsResult : Result<FindFakeidsResultData>
    {
    }

    public class FindFakeidsResultData : ResultData, IResultData
    {
        public List<KeywordFakeidData> FindDataList { get; set; }

        public FindFakeidsResultData()
        {
            FindDataList = new List<KeywordFakeidData>();
        }
    }

    public class KeywordFakeidData
    {        
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// Fakeid
        /// </summary>
        public string Fakeid { get; set; }

    }
}