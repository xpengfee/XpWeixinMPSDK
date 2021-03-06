﻿#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Enum
//
// 文件功能描述
// 枚举管理
// 
// 创建标识：xupeng Create at 2014/1/16 15:00:23
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
    /// <summary>
    /// 返回结果类型
    /// </summary>
    public enum ResultKind
    {
        成功 = 0,

        账户验证失败 = -1000,

        账户被停用 = -2000,
        账户被停用_尚未通过审核 = -2001,
        账户被停用_已关闭 = -2002,
        账户被停用_状态异常 = -2003,

        包含违法信息 = -3000,

        执行过程发生异常 = -4000,
        执行过程发生异常_API地址错误 = -4001,
        执行过程发生异常_积分不足 = -4002,

        发送消息失败 = -5000,
        发送消息失败_用户不存在 = -5001,
        发送消息失败_需要验证码 = -5003,
        发送消息失败_请求被禁止 = -5005,
        发送消息失败_不能发送_对方不是你的粉丝 = -5006,
        发送消息失败_对方关闭了接收消息 = -5007,
        发送消息失败_该用户已被加入黑名单_无法向此发送消息 = -5008,
        发送消息失败_引用错误 = -5009,
        发送消息失败_NeedPost = -5010,
        发送消息失败_24小时内用户未互动 = -5011,

        P2PBridge错误 = -6000,
        P2PBridge错误_Url未正确设置 = -6001,

        资源获取失败 = -7000,
        资源获取失败_资源不存在 = -7001,
        资源获取失败_音频时间太长 = -7002,
        资源获取失败_参数错误 = -7003
        //P2PServer进程注册失败 = -9000,
    }

    /// <summary>
    /// 性别
    /// </summary>
    public enum WeixinSex
    {
        未设置 = 0,
        男 = 1,
        女 = 2,
    }

    /// <summary>
    /// 语言
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// 中文简体
        /// </summary>
        zh_CN,
        /// <summary>
        /// 中文繁体
        /// </summary>
        zh_TW,
        /// <summary>
        /// 英文
        /// </summary>
        en
    }

    /// <summary>
    /// 上传媒体文件类型
    /// </summary>
    public enum UploadMediaFileType
    {
        /// <summary>
        /// 图片: 128K，支持JPG格式
        /// </summary>
        image,
        /// <summary>
        /// 语音：256K，播放长度不超过60s，支持AMR\MP3格式
        /// </summary>
        voice,
        /// <summary>
        /// 视频：1MB，支持MP4格式
        /// </summary>
        video,
        /// <summary>
        /// thumb：64KB，支持JPG格式
        /// </summary>
        thumb,
        /// <summary>
        /// 图文消息
        /// </summary>
        news
    }

    /// <summary>
    /// 返回码（JSON）
    /// </summary>
    public enum ReturnCode
    {
        系统繁忙 = -1,
        请求成功 = 0,
        验证失败 = 40001,
        不合法的凭证类型 = 40002,
        不合法的OpenID = 40003,
        不合法的媒体文件类型 = 40004,
        不合法的文件类型 = 40005,
        不合法的文件大小 = 40006,
        不合法的媒体文件id = 40007,
        不合法的消息类型 = 40008,
        不合法的图片文件大小 = 40009,
        不合法的语音文件大小 = 40010,
        不合法的视频文件大小 = 40011,
        不合法的缩略图文件大小 = 40012,
        不合法的APPID = 40013,
        不合法的access_token = 40014,
        不合法的菜单类型 = 40015,
        不合法的按钮个数 = 40016,
        不合法的按钮个数1 = 40017,
        不合法的按钮名字长度 = 40018,
        不合法的按钮KEY长度 = 40019,
        不合法的按钮URL长度 = 40020,
        不合法的菜单版本号 = 40021,
        不合法的子菜单级数 = 40022,
        不合法的子菜单按钮个数 = 40023,
        不合法的子菜单按钮类型 = 40024,
        不合法的子菜单按钮名字长度 = 40025,
        不合法的子菜单按钮KEY长度 = 40026,
        不合法的子菜单按钮URL长度 = 40027,
        不合法的自定义菜单使用用户 = 40028,
        不合法的oauth_code = 40029,
        不合法的refresh_token = 40030,
        不合法的openid列表 = 40031,
        不合法的openid列表长度 = 40032,
        不合法的请求字符不能包含特殊格式的字符 = 40033,
        不合法的参数 = 40035,
        不合法的请求格式 = 40038,
        不合法的URL长度 = 40039,
        不合法的分组id = 40050,
        分组名字不合法 = 40051,
        缺少access_token参数 = 41001,
        缺少appid参数 = 41002,
        缺少refresh_token参数 = 41003,
        缺少secret参数 = 41004,
        缺少多媒体文件数据 = 41005,
        缺少media_id参数 = 41006,
        缺少子菜单数据 = 41007,
        缺少oauth ,code = 41008,
        缺少openid = 41009,
        access_token超时 = 42001,
        refresh_token超时 = 42002,
        oauth_code超时 = 42003,
        需要GET请求 = 43001,
        需要POST请求 = 43002,
        需要HTTPS请求 = 43003,
        需要接收者关注 = 43004,
        需要好友关系 = 43005,
        多媒体文件为空 = 44001,
        POST的数据包为空 = 44002,
        图文消息内容为空 = 44003,
        文本消息内容为空 = 44004,
        多媒体文件大小超过限制 = 45001,
        消息内容超过限制 = 45002,
        标题字段超过限制 = 45003,
        描述字段超过限制 = 45004,
        链接字段超过限制 = 45005,
        图片链接字段超过限制 = 45006,
        语音播放时间超过限制 = 45007,
        图文消息超过限制 = 45008,
        接口调用超过限制 = 45009,
        创建菜单个数超过限制 = 45010,
        回复时间超过限制 = 45015,
        系统分组,不允许修改 = 45016,
        分组名字过长 = 45017,
        分组数量超过上限 = 45018,
        不存在媒体数据 = 46001,
        不存在的菜单版本 = 46002,
        不存在的菜单数据 = 46003,
        不存在的用户 = 46004,
        解析JSON_XML内容错误 = 47001,
        api功能未授权 = 48001,
        用户未授权该api = 50001,

        //新加入的一些类型，以下文字根据P2P项目格式组织，非官方文字
        发送消息失败_48小时内用户未互动 = 10706,
        发送消息失败_该用户已被加入黑名单_无法向此发送消息 = 62751,
        发送消息失败_对方关闭了接收消息 = 10703,
        对方不是粉丝 = 10700
    }

}