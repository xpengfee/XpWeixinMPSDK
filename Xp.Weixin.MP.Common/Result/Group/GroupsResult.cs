#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2014 云合畅想科技（北京）有限公司 版权所有。 
//
// 文件名 GetGroupsResult
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/1/16 10:51:47
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

namespace YQZT.Weixin.MP.SDK.Common
{
    public class GroupsResult : Result<GroupsData>
    {
    }
    
    public class GroupsData : IResultData
    {
        public List<GroupData> GroupDataList { get; set; }

        public GroupsData()
        {
            GroupDataList = new List<GroupData>();
        }
    }

    /// <summary>
    /// 分组信息
    /// </summary>
    public class GroupData
    {
        /// <summary>
        /// 分组编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 分组名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 组内总人数
        /// </summary>
        public int cnt { get; set; }
    }
}