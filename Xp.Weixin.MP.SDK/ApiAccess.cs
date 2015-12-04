#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 ApiAccess
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/1/16 11:39:39
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------
#endregion
using System;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Collections.Generic;

namespace Xp.Weixin.MP.SDK
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
    /// </summary>
    public sealed class ApiAccess
    {
        public ApiAccess()
        { }

        #region CreateObject

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = CacheManager.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    CacheManager.SetCache(classNamespace, objType);// 写入缓存
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion
        
        /// <summary>
        /// 创建FriendApi接口。
        /// </summary>
        public static IFriend Create_FriendApi(string AssemblyPath)
        {
            string ClassNamespace = AssemblyPath + ".Friend";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IFriend)objType;
        }
        /// <summary>
        /// 创建MediaApi接口。
        /// </summary>
        public static IMedia Create_MediaApi(string AssemblyPath)
        {
            string ClassNamespace = AssemblyPath + ".Media";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IMedia)objType;
        }

        /// <summary>
        /// 创建MessageApi接口。
        /// </summary>
        public static IMessage Create_MessageApi(string AssemblyPath)
        {
            string ClassNamespace = AssemblyPath + ".Message";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IMessage)objType;
        }
    }
}