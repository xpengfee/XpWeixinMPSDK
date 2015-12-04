using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xp.Weixin.MP.Common;
using Xp.Weixin.MP.SDK.Api.CommonAPIs;
using Xp.Weixin.MP.SDK.Api.HttpUtility;

namespace Xp.Weixin.MP.SDK.Api.AdvancedAPIs.TemplateMessage
{
    /// <summary>
    /// 模板消息接口
    /// </summary>
    public static class Template
    {
        public static WxJsonResult SendTemplateMessage<T>(string accessToken, string openId, string templateId, string topcolor, T data)
        {
            const string urlFormat = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";
            var msgData = new TempleteModel()
            {
                template_id = templateId,
                topcolor = topcolor,
                touser = openId,
                data = data
            };
            return CommonJsonSend.Send<WxJsonResult>(accessToken, urlFormat, msgData);
        }
    }
}