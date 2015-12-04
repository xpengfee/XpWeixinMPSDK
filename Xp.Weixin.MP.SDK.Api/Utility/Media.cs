#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2015 xpengfee 版权所有。 
//
// 文件名 Media
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2014/3/17 10:15:24
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------
#endregion
using System;
using System.Net;
using System.Text;
using System.Collections.Generic;

using Newtonsoft.Json;
using Xp.Weixin.MP.Common;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using Xp.Weixin.MP.SDK.Api.CommonAPIs;

namespace Xp.Weixin.MP.SDK.Api.Utility
{
    public class Media
    {
        /// <summary>
        /// 功能：获取图文素材信息接口
        /// 作者：xupeng
        /// 时间：2014-03-17
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static AppMsgResult GetAppMsgList(string token, CookieContainer cookie)
        {
            AppMsgResult result = new AppMsgResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "获取图文素材信息异常";

            string cUrl = "https://mp.weixin.qq.com/cgi-bin/appmsg?begin=0&count=10&t=media/appmsg_list&type=10&action=list&token=" + token + "&lang=zh_CN";
            
            try
            {
                string cResult = Http.Instance.GetPage(cUrl, cUrl, cookie);

                
                if (cResult.IndexOf("登录超时，请重新") > 0)
                {
                    result.Ret = ResultKind.账户验证失败;
                    result.ErrorMessage = "账户模拟登录失败";
                }
                else
                {
                    string jsonmsglist = Tools.GetValue(cResult, "wx.cgiData = ", "wx.cgiData.count");

                    jsonmsglist = jsonmsglist.Substring(0, jsonmsglist.LastIndexOf(";"));

                    //此处用到了newtonsoft来序列化
                    AppMsgData data = JsonConvert.DeserializeObject<AppMsgData>(jsonmsglist);

                    if (data != null)
                    {
                        result.Data = data;
                        result.Ret = ResultKind.成功;
                        result.ErrorMessage = "获取图文素材信息成功";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ret = ResultKind.执行过程发生异常;
                result.ErrorMessage = ex.ToString();
            }

            return result;
        }

        /// <summary>
        /// 功能：上传图文素材信息接口
        /// 作者：xupeng
        /// 时间：2014-03-17
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cookie"></param>
        /// <param name="userName"></param>
        /// <param name="ticket"></param>
        /// <param name="articleList"></param>
        /// <returns></returns>
        public static OrginNewsResult OrginNews(string token, CookieContainer cookie, string userName, string ticket, List<Article> articleList)
        {
            OrginNewsResult result = new OrginNewsResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "上传图文素材信息异常";

            string cUrl = "https://mp.weixin.qq.com/cgi-bin/operate_appmsg?token=" + token + "&lang=zh_CN&t=ajax-response&sub=create";
            string cReferer = "https://mp.weixin.qq.com/cgi-bin/operate_appmsg?token=" + token + "&lang=zh_CN&sub=edit&t=wxm-appmsgs-edit-new&type=10&subtype=3&lang=zh_CN";

            try
            {
                StringBuilder sbPayload = new StringBuilder();
                sbPayload.AppendFormat("error=false&count={0}&AppMsgId=", articleList.Count);

                int i = 0;
                foreach (Article article in articleList)
                {
                    //1.上传封面图片
                    string fileId = UploadMaterialFile(token,cookie,userName,ticket,article.FileSrc);
                    sbPayload.AppendFormat("&title{0}={1}&digest{2}={3}&author{4}={5}&content{6}={7}&sourceurl{8}={9}&description0=&fileid{10}={11}&show_cover_pic{12}={13}",
                        i, System.Web.HttpUtility.UrlEncode(article.Title), i, System.Web.HttpUtility.UrlEncode(article.Digest),
                        i, System.Web.HttpUtility.UrlEncode(article.Author), i, System.Web.HttpUtility.UrlEncode("<p>" + article.Content + "</p>"),
                        i, System.Web.HttpUtility.UrlEncode(article.SourceUrl), i, fileId,
                        i,article.Show_cover_pic);

                    i++;
                }

                sbPayload.AppendFormat("&token={0}&ajax=1", token);

                string cResult = Http.Instance.Post(cUrl, cReferer, cookie, sbPayload.ToString());


                if (cResult.IndexOf("登录超时，请重新") > 0)
                {
                    result.Ret = ResultKind.账户验证失败;
                    result.ErrorMessage = "账户模拟登录失败";
                }
                else
                {
                     string textresult=string.Empty;
                     if (cResult.IndexOf("base_resp") > -1)
                         textresult = Tools.GetValue(cResult, "{\"base_resp\":", "}") + "}";
                     else
                         textresult = cResult;

                    OrginNewsJsonData json = JsonConvert.DeserializeObject<OrginNewsJsonData>(textresult);
                    if (json != null)
                    {
                        OrginNewsResultData data = new OrginNewsResultData();
                        data.orginNewsJson = json;

                        result.Data = data;
                        result.Ret = ResultKind.成功;
                        result.ErrorMessage = "上传图文素材信息成功";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ret = ResultKind.执行过程发生异常;
                result.ErrorMessage = ex.ToString();
            }

            return result;
        }

        /// <summary>
        /// 功能：上传文件素材,返回素材编号
        /// 作者：xupeng
        /// 时间：2014-03-17
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cookie"></param>
        /// <param name="userName"></param>
        /// <param name="ticket"></param>
        /// <param name="fileSrc"></param>
        /// <returns></returns>
        public static string UploadMaterialFile(string token, CookieContainer cookie, string userName, string ticket, string fileSrc)
        {
            string fileId = string.Empty;

            string newurl = "https://mp.weixin.qq.com/cgi-bin/filetransfer?action=upload_material&f=json&ticket_id={0}&ticket={1}&token={2}&lang=zh_CN";
            newurl = string.Format(newurl, userName, ticket, token);

            string referer = string.Format("https://mp.weixin.qq.com/cgi-bin/appmsg?t=media/appmsg_edit&action=edit&type=10&isMul=0&lang=zh_CN&token={0}", token);

            HttpWebRequest req = null;
            HttpWebResponse resp = null;

            try
            {
                string fileName = Path.GetFileName(fileSrc);
                string filePath = fileSrc;                     //要上传文件本地路径，如D:\\ms.jpg
                byte[] filebytes = File.ReadAllBytes(filePath);
                string boundary = "----" + DateTime.Now.Ticks.ToString("x");

                //参数中ticket_id和ticket跟自己登录的微信号有关
                req = (HttpWebRequest)WebRequest.Create(newurl);
                req.Method = "POST";
                req.Accept = "*/*";
                req.AllowAutoRedirect = true;
                req.Credentials = System.Net.CredentialCache.DefaultCredentials;
                req.Referer = referer;

                req.Host = "mp.weixin.qq.com";
                req.ContentType = "multipart/form-data; boundary=" + boundary;
                req.KeepAlive = true;
                req.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                if (cookie != null)
                {
                    req.CookieContainer = new CookieContainer();
                    req.CookieContainer = cookie;
                }

                #region 组织数据
                byte[] boundarybyte = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
                byte[] fileHeader = Encoding.UTF8.GetBytes("Content-Disposition: form-data; name=\"file\"; filename=\"" + fileName + "\"\r\nContent-Type: application/octet-stream\r\n\r\n"); //2.jpg为上传后保存的文件名，通过修改image/jpeg可以上传音频
                byte[] formData = Encoding.UTF8.GetBytes("Content-Disposition: form-data; name=\"formId\"\r\n\r\n");
                byte[] trailer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--");

                Stream memStream = new MemoryStream();
                memStream.Write(fileHeader, 0, fileHeader.Length);
                memStream.Write(boundarybyte, 0, boundarybyte.Length);
                memStream.Write(fileHeader, 0, fileHeader.Length);
                memStream.Write(filebytes, 0, filebytes.Length);
                memStream.Write(boundarybyte, 0, boundarybyte.Length);
                memStream.Write(formData, 0, formData.Length);
                memStream.Write(trailer, 0, trailer.Length);
                req.ContentLength = memStream.Length;

                memStream.Position = 0;
                byte[] tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                #endregion


                Stream reqStream = req.GetRequestStream();
                reqStream.Write(tempBuffer, 0, tempBuffer.Length);
                reqStream.Close();

                resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                string html = sr.ReadToEnd().Trim();//输出结果
                resp.Close();

                fileId = Regex.Match(html, "(?<=content\":\").+?(?=\")").Value;
            }
            catch (Exception ex)
            {
                fileId = "";
            }
            finally
            {
                if (req != null)
                    req.Abort();
                if (resp != null)
                    resp.Close();
            }

            return fileId;
        }

        /// <summary>
        /// 功能：上传文件素材
        /// 作者：xupeng
        /// 时间：2014-04-10
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cookie"></param>
        /// <param name="userName"></param>
        /// <param name="ticket"></param>
        /// <param name="fileSrc"></param>
        /// <returns></returns>
        public static UploadFileResult UploadFile(string token, CookieContainer cookie, string userName, string ticket, string fileSrc)
        {
            UploadFileResult result = new UploadFileResult();
            result.Ret = ResultKind.执行过程发生异常;
            result.ErrorMessage = "上传图片信息异常";

            string newurl = "https://mp.weixin.qq.com/cgi-bin/filetransfer?action=upload_material&f=json&ticket_id={0}&ticket={1}&token={2}&lang=zh_CN";
            newurl = string.Format(newurl, userName, ticket, token);

            string referer = string.Format("https://mp.weixin.qq.com/cgi-bin/appmsg?t=media/appmsg_edit&action=edit&type=10&isMul=0&lang=zh_CN&token={0}", token);

            HttpWebRequest req = null;
            HttpWebResponse resp = null;

            try
            {
                string fileName = Path.GetFileName(fileSrc);
                string filePath = fileSrc;                     //要上传文件本地路径，如D:\\ms.jpg
                byte[] filebytes = File.ReadAllBytes(filePath);
                string boundary = "----" + DateTime.Now.Ticks.ToString("x");

                //参数中ticket_id和ticket跟自己登录的微信号有关
                req = (HttpWebRequest)WebRequest.Create(newurl);
                req.Method = "POST";
                req.Accept = "*/*";
                req.AllowAutoRedirect = true;
                req.Credentials = System.Net.CredentialCache.DefaultCredentials;
                req.Referer = referer;

                req.Host = "mp.weixin.qq.com";
                req.ContentType = "multipart/form-data; boundary=" + boundary;
                req.KeepAlive = true;
                req.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                if (cookie != null)
                {
                    req.CookieContainer = new CookieContainer();
                    req.CookieContainer = cookie;
                }

                #region 组织数据
                byte[] boundarybyte = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
                byte[] fileHeader = Encoding.UTF8.GetBytes("Content-Disposition: form-data; name=\"file\"; filename=\"" + fileName + "\"\r\nContent-Type: application/octet-stream\r\n\r\n"); //2.jpg为上传后保存的文件名，通过修改image/jpeg可以上传音频
                byte[] formData = Encoding.UTF8.GetBytes("Content-Disposition: form-data; name=\"formId\"\r\n\r\n");
                byte[] trailer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--");

                Stream memStream = new MemoryStream();
                memStream.Write(fileHeader, 0, fileHeader.Length);
                memStream.Write(boundarybyte, 0, boundarybyte.Length);
                memStream.Write(fileHeader, 0, fileHeader.Length);
                memStream.Write(filebytes, 0, filebytes.Length);
                memStream.Write(boundarybyte, 0, boundarybyte.Length);
                memStream.Write(formData, 0, formData.Length);
                memStream.Write(trailer, 0, trailer.Length);
                req.ContentLength = memStream.Length;

                memStream.Position = 0;
                byte[] tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                #endregion


                Stream reqStream = req.GetRequestStream();
                reqStream.Write(tempBuffer, 0, tempBuffer.Length);
                reqStream.Close();

                resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                string html = sr.ReadToEnd().Trim();//输出结果
                resp.Close();

                UploadFileJsonData json = JsonConvert.DeserializeObject<UploadFileJsonData>(html);
                if (json != null)
                {
                    UploadFileResultData data = new UploadFileResultData();
                    data.uploadFileJson = json;

                    result.Data = data;
                    result.Ret = ResultKind.成功;
                    result.ErrorMessage = "上传图片信息成功";
                }
            }
            catch (Exception ex)
            {
                result.Ret = ResultKind.执行过程发生异常;
                result.ErrorMessage = ex.ToString();
            }
            finally
            {
                if (req != null)
                    req.Abort();
                if (resp != null)
                    resp.Close();
            }

            return result;
        }
    
    }
}