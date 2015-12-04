#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Article
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/1/15 16:34:05
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
    public class Article
    {
        /// <summary>
        /// 封面图片全路径(自定义接口：文件是本地；Souidea接口：文件必须能在公网上访问)
        /// </summary>
        public string FileSrc { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Digest { get; set; }
        public string Content { get; set; }

        /// <summary>
        /// 原文链接（自定义接口使用）
        /// </summary>
        public string SourceUrl { get; set; }

        /// <summary>
        /// 封面图片是否显示在正文中 xupeng 2014-03-26新增
        /// </summary>
        public int Show_cover_pic { get; set; }

        //====================================
        /// <summary>
        /// 用于高级接口 文章web访问地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 用于高级接口 图文web访问地址
        /// </summary>
        public string PicUrl { get; set; }
    }
}