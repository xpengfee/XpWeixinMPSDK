#region Copyright
//----------------------------------------------------------------
// Copyright (C) 2013 云合畅想科技（北京）有限公司 版权所有。 
//
// 文件名 Http
//
// 文件功能描述
// TODO
// 
// 创建标识：xupeng Create at 2013/11/5 15:13:33
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------
#endregion
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Xp.Weixin.MP.SDK.Api.CommonAPIs
{
    public class Http
    {
        private static Http instance = new Http(System.Text.Encoding.UTF8);

        public static Http Instance
        {
            get { return instance; }
        }

        #region 私有变量

        /// <summary>
        /// 对象集合容器
        /// </summary>
        private CookieContainer cookieCon = new CookieContainer();

        /// <summary>
        /// 为多个凭据提供存储
        /// </summary>
        private CredentialCache credentials;


        /// <summary>
        /// 编码
        /// </summary>
        private System.Text.Encoding m_encoding;
        /// <summary>
        /// 超时时间
        /// </summary>
        private int m_timeout = 30000;
        /// <summary>
        /// 是否使用代码服务器：0 不使用  1 使用代理服务器
        /// </summary>
        private int m_proxyState = 0;
        /// <summary>
        /// 代理服务器地址
        /// </summary>
        private string m_proxyAddress = null;
        /// <summary>
        /// 代理服务器端口
        /// </summary>
        private string m_proxyPort = null;
        /// <summary>
        /// 代理服务器用户名
        /// </summary>
        private string m_proxyAccount = null;
        /// <summary>
        /// 代理服务器密码
        /// </summary>
        private string m_proxyPassword = null;
        /// <summary>
        /// 代理服务器域
        /// </summary>
        private string m_proxyDomain = null;
        /// <summary>
        /// 输出文件路径
        /// </summary>
        private string m_outFilePath = null;

        #endregion

        #region 公共属性


        /// <summary>
        /// 超时设置
        /// </summary>
        public int TimeOut
        {
            get { return m_timeout; }
            set { m_timeout = value; }

        }
        /// 是否使用代理服务器标志
        /// </summary>
        public int ProxyState
        {
            get { return m_proxyState; }
            set { m_proxyState = value; }
        }
        /// <summary>
        /// 代理服务器地址
        /// </summary>
        public string ProxyAddress
        {
            get { return m_proxyAddress; }
            set { m_proxyAddress = value; }
        }
        /// <summary>
        /// 代理服务器端口
        /// </summary>
        public string ProxyPort
        {
            get { return m_proxyPort; }
            set { m_proxyPort = value; }
        }

        /// <summary>
        /// 代理服务器账号
        /// </summary>
        public string ProxyAccount
        {
            get { return m_proxyAccount; }
            set { m_proxyAccount = value; }
        }

        /// <summary>
        /// 代理服务器密码
        /// </summary>
        public string ProxyPassword
        {
            get { return m_proxyPassword; }
            set { m_proxyPassword = value; }
        }

        /// <summary>
        /// 代理服务器域
        /// </summary>
        public string ProxyDomain
        {
            get { return m_proxyDomain; }
            set { m_proxyDomain = value; }
        }


        #endregion

        #region 构造函数

        public Http()
        {
            m_encoding = System.Text.Encoding.UTF8;
        }
        public Http(Encoding encoding)
        {
            m_encoding = encoding;
        }

        #endregion

        /// <summary>
        /// 功能：Post
        /// 作者：xpengfee
        /// 时间：2012-6-12 14:20
        /// </summary>
        /// <param name="payData">订单数据</param>
        /// <param name="cUrl">接口地址</param>
        public string Post(string cUrl,string cReferer,CookieContainer cookie, string payData)
        {
            string cResult = string.Empty;
            HttpWebRequest myReq = null;
            HttpWebResponse response = null;
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(payData);

                myReq = (HttpWebRequest)WebRequest.Create(cUrl);

                myReq.CookieContainer = cookie; //登录时得到的缓存
                myReq.Referer = cReferer;
                myReq.Method = "POST";
                myReq.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                myReq.ContentType = "application/x-www-form-urlencoded";
                myReq.ContentLength = byteArray.Length;

                Stream reqStream = myReq.GetRequestStream();
                // Send the data.            
                reqStream.Write(byteArray, 0, byteArray.Length);    //写入参数   
                reqStream.Close();

                response = (HttpWebResponse)myReq.GetResponse();

                StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                cResult = myStreamReader.ReadToEnd();

            }
            catch (WebException ex)
            {
                cResult = "";
            }
            finally
            {
                if (myReq != null)
                    myReq.Abort();
                if (response != null)
                    response.Close();
            }

            return cResult;
        }

        /// <summary>
        /// 通过url请求数据
        /// </summary>
        /// <param name="cUrl">被请求页面的url</param>
        /// <returns>返回页面内容</returns>
        public string GetPage(string cUrl,string cReferer,CookieContainer cookie)
        {
            string cResult = string.Empty;
            
            HttpWebRequest myReq = null;
            HttpWebResponse response = null;

            try
            {
                myReq = (HttpWebRequest)WebRequest.Create(cUrl);
                myReq.CookieContainer = cookie; //登录时得到的缓存
                myReq.Referer = cReferer;
                myReq.Method = "GET";
                myReq.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                myReq.ContentType = "text/html;";

                response = (HttpWebResponse)myReq.GetResponse();
                Stream ReceiveStream = response.GetResponseStream();

                System.Text.Encoding srEncoding;
                if (m_encoding == null)
                    srEncoding = System.Text.Encoding.Default;
                else
                    srEncoding = m_encoding;

                StreamReader sr = new StreamReader(ReceiveStream, srEncoding);

                cResult = sr.ReadToEnd();
            }
            catch (WebException WebExcp)
            {
                cResult = "";

                string strErr = cUrl + "\r\n";
                strErr = strErr + WebExcp.Message + "\r\n";
                throw new ApplicationException(strErr, WebExcp);
            }
            catch (UriFormatException UriExcp)
            {
                cResult = "";

                throw new ApplicationException("Uri格式异常:\r\n" + cUrl + UriExcp.Message, UriExcp);
            }
            catch (Exception exc)
            {
                cResult = "";

                throw new ApplicationException(exc.ToString(), exc);
            }
            finally
            {
                if (myReq != null)
                    myReq.Abort();
                if (response != null)
                    response.Close();
            }

            return cResult;
        }

        /// <summary>
        /// 获取网络图片
        /// </summary>
        /// <param name="url">被请求页面的url</param>
        /// <param name="proxyServer">代理服务器</param>
        /// <returns>返回页面内容</returns>
        public byte[] GetImage(string url, string proxyServer, CookieContainer cookie)
        {
            byte[] arrReturn = null;

            HttpWebRequest req = null;
            HttpWebResponse rsp = null;

            try
            {
                Uri uri = new Uri(url);
                req = (HttpWebRequest)WebRequest.Create(uri);
                if (!string.IsNullOrEmpty(proxyServer))
                {
                    req.Proxy = new WebProxy(proxyServer);
                }

                req.Method = "GET";
                req.Accept = "*/*";
                req.ContentType = "application/x-www-form-urlencoded";
                req.AllowAutoRedirect = true;
                req.Timeout = m_timeout;
                req.CookieContainer = cookie;

                rsp = (HttpWebResponse)req.GetResponse();

                //if (!rsp.ContentType.StartsWith("image"))
                //    throw new ApplicationException("取图片异常:");
                if (!rsp.ContentType.StartsWith("image"))
                {
                    arrReturn = null;
                }
                else
                {
                    Stream rspStream = rsp.GetResponseStream();

                    MemoryStream ms = new MemoryStream();

                    byte[] read = new byte[256];

                    int count = rspStream.Read(read, 0, 256);

                    float percent = 256;

                    while (count > 0)
                    {
                        ms.Write(read, 0, count);
                        count = rspStream.Read(read, 0, 256);

                        percent += count;

                    }
                    arrReturn = ms.ToArray();

                    ms.Close();
                    rspStream.Close();
                }
            }
            catch (Exception e)
            {
                arrReturn = null;
            }
            finally
            {
                if (req != null)
                {
                    req.Abort();
                    req = null;
                }
                if (rsp != null)
                {
                    rsp.Close();
                }

            }
            return arrReturn;
        }


        public static T ResolveByForm<T>(NameValueCollection form, T e)
        {
            try
            {
                Type t = typeof(T);
                PropertyInfo[] ps = t.GetProperties();
                PropertyInfo pi;
                object o;
                string value;
                for (int i = 0; i < ps.Length; i++)
                {
                    pi = ps[i];
                    value = form[pi.Name];
                    if (pi != null && !string.IsNullOrEmpty(value) && pi.PropertyType.IsPublic)
                    {
                        if (pi.PropertyType.IsGenericType)
                        {
                            o = Convert.ChangeType(value, pi.PropertyType.GetGenericArguments()[0]);
                        }
                        else
                        {
                            o = Convert.ChangeType(value, pi.PropertyType);
                        }
                        pi.SetValue(e, o, null);
                    }
                }
                return e;
            }
            catch
            {

            }
            return default(T);
        }

        public static T ResolveByForm<T>(NameValueCollection form)
        {
            T e = Activator.CreateInstance<T>();
            return ResolveByForm<T>(form, e);
        }
    }
}