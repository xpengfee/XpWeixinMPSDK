#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Tools
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/1/16 16:43:42
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

namespace Xp.Weixin.MP.SDK.Api.Utility
{
    public class Tools
    {
        /// <summary>
        /// 获得字符串中开始和结束字符串中间得值
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="s">开始</param>
        /// <param name="e">结束</param>
        /// <returns></returns> 
        public static string GetValue(string str, string s, string e)
        {
            int startindex = str.IndexOf(s) + s.Length;
            int endindex = str.IndexOf(e);
            string strresult = str.Substring(startindex, endindex - startindex);
            return strresult;
        }
    }
}