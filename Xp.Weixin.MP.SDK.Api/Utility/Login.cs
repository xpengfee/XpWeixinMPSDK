using System;
using System.IO;
using System.Net;
using System.Text;
using System.Security.Cryptography;

using Newtonsoft.Json;
using Xp.Weixin.MP.Common;
using Xp.Weixin.MP.SDK.Api.CommonAPIs;

namespace Xp.Weixin.MP.SDK.Api.Utility
{
    public class Login
    {
        /// <summary>
        /// MD5　32位加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        static string GetMd5Str32(string password)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            // Convert the input string to a byte array and compute the hash.  
            char[] temp = password.ToCharArray();
            byte[] buf = new byte[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                buf[i] = (byte)temp[i];
            }
            byte[] data = md5Hasher.ComputeHash(buf);
            // Create a new Stringbuilder to collect the bytes  
            // and create a string.  
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data   
            // and format each one as a hexadecimal string.  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.  
            return sBuilder.ToString();
        }

        /// <summary>
        /// 模拟登录公众平台
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static LoginResult SimulateLogin(string userName, string password)
        {
            CookieContainer cookie = new CookieContainer();//接收缓存

            LoginResult retinfo = new LoginResult();
            retinfo.Ret = ResultKind.执行过程发生异常;
            retinfo.ErrorMessage = "模拟登录失败";

            string md5Password = GetMd5Str32(password).ToLower();
            string paydata = "username=" + userName + "&pwd=" + md5Password + "&imgcode=&f=json";
            string cUrl = "https://mp.weixin.qq.com/cgi-bin/login?lang=zh_CN ";//请求登录的URL
            string cReferer = "https://mp.weixin.qq.com/cgi-bin/loginpage?lang=zh_CN&t=wxm2-login";
            //string cReferer = "http://mp.weixin.qq.com";

            try
            {
                string cResult = Http.Instance.Post(cUrl, cReferer, cookie, paydata);

                //此处用到了newtonsoft来序列化
                LoginJsonResultData loginJsonResultData = JsonConvert.DeserializeObject<LoginJsonResultData>(cResult);
                string token = string.Empty;
                if (loginJsonResultData.redirect_url.Length > 0)
                {
                    token = loginJsonResultData.redirect_url.Split(new char[] { '&' })[2].Split(new char[] { '=' })[1].ToString();//取得令牌

                    Passport passport = new Passport();

                    passport.LoginCookie = cookie;
                    passport.CreateDate = DateTime.Now;
                    passport.Token = token;

                    LogUserJsonInfo wxLoginInfo = GetLoginInfo(passport.Token, passport.LoginCookie);
                    if (wxLoginInfo != null)
                    {
                        passport.Ticket = wxLoginInfo.ticket;
                        passport.UserName = wxLoginInfo.user_name;
                        passport.Password = password;
                    }

                    LoginResultData loginResultData = new LoginResultData();
                    loginResultData.LoginJsonResult = loginJsonResultData;
                    loginResultData.PassPort = passport;

                    retinfo.Data = loginResultData;                    
                    retinfo.Ret = ResultKind.成功;
                    retinfo.ErrorMessage = "模拟登录成功";
                }
            }
            catch (Exception ex)
            {
                retinfo.ErrorMessage = ex.ToString();
            }

            return retinfo;
        }

        /// <summary>
        /// 获取账号登录信息（Ticket等）
        /// </summary>
        /// <returns></returns>
        private static LogUserJsonInfo GetLoginInfo(string token, CookieContainer cookie)
        {
            LogUserJsonInfo retinfo = null;

            string cUrl = "https://mp.weixin.qq.com/cgi-bin/home?t=home/index&lang=zh_CN&token=" + token;
            string cReferer = "https://mp.weixin.qq.com/";

            try
            {
                string cResult = Http.Instance.GetPage(cUrl, cReferer, cookie);
                string jsonmsglist = Tools.GetValue(cResult, "data:", "path:{");
                jsonmsglist = jsonmsglist.Replace(Tools.GetValue(jsonmsglist, "param:", "uin:"), "10,");
                jsonmsglist = jsonmsglist.Substring(0, jsonmsglist.LastIndexOf("||")) + "}";

                //此处用到了newtonsoft来序列化
                retinfo = JsonConvert.DeserializeObject<LogUserJsonInfo>(jsonmsglist);
            }
            catch (Exception ex)
            {
                retinfo = null;
            }

            return retinfo;
        }
    }
}
