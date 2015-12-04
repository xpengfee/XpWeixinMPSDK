using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;

using Xp.Weixin.MP.Common;

namespace Xp.Weixin.MP.SDK.Api
{
    public class SdkManager
    {
        private static PassportCollection _passportCollection;
        public static PassportCollection PassportCollection
        {
            get
            {
                if (_passportCollection == null)
                {
                    //LoadPassport();
                    _passportCollection = new PassportCollection();
                }
                return _passportCollection;
            }
            set { _passportCollection = value; }
        }

        public static PassportBag GetPassportBag(string userName)
        {
            if (PassportCollection.ContainsKey(userName))
            {
                return PassportCollection[userName];
            }
            return null;
        }


        /// <summary>
        /// 注册应用基本信息（可以选择不立即载入Passport以节省系统启动时间）
        /// </summary>
        /// <param name="userName">P2P后台申请到微信应用后的userName</param>
        /// <param name="password">userName对应的Secret</param>
        /// <param name="url">API地址，建议使用默认值</param>
        /// <param name="getPassportImmediately">是否马上获取Passport，默认为False</param>
        private static void Register(string userName, string password, bool getPassportImmediately = false)
        {
            PassportCollection[userName] = new PassportBag(userName, password);
            if (getPassportImmediately)
            {
                ApplyPassport(userName, password);
            }
        }

        /// <summary>
        /// 申请新的通行证。
        /// 每次调用完毕前将有1秒左右的Thread.Sleep时间
        /// </summary>
        public static void ApplyPassport(string userName, string password)
        {
            if (!PassportCollection.ContainsKey(userName))
            {
                //如果不存在，则自动注册（注册之后PassportCollection[userName]一定有存在值）
                Register(userName, password, false);
            }

            var passportBag = PassportCollection[userName];

            var result = Utility.Login.SimulateLogin(passportBag.UserName, passportBag.Password);

            if (result.Ret != ResultKind.成功)
            {
                throw new Exception("获取Passort失败！错误信息：" + result.ErrorMessage, null);
            }

            passportBag.Passport = result.Data.PassPort;

            //为了更加贴近真是登录，并且防止502等页面错误产生，这里适当添加一些间隔时间
            Thread.Sleep(1000);
        }

        /// <summary>
        /// 清除当前的通行证
        /// </summary>
        public static void RemovePassport(string userName)
        {
            try
            {
                PassportCollection.Remove(userName);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 获取userName对应的接口集合。
        /// 调用此方法请确认此userName已经成功使用SdkManager.Register(userName, password, appUrl)方法注册过。
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static ApiContainer GetApiContainer(string userName, string password)
        {
            return new ApiContainer(userName, password);
        }
    }
}
