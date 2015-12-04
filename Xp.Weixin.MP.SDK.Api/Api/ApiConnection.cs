using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Xp.Weixin.MP.Common;

namespace Xp.Weixin.MP.SDK.Api
{
    public class ApiConnection
    {
        private Passport _passport;
        public ApiConnection(Passport passport)
        {
            if (passport == null)
            {
                throw new Exception("Passport不可以为NULL！");
            }
            _passport = passport;
        }

        /// <summary>
        /// 自动更新Passport的链接方法
        /// </summary>
        /// <param name="apiFunc"></param>
        /// <returns></returns>
        public IResult<T> Connection<T>(Func<IResult<T>> apiFunc) where T : IResultData
        {
            var result = apiFunc();
            if (result.Ret == ResultKind.账户验证失败)
            {
                //更新Passport
                SdkManager.ApplyPassport(_passport.UserName, _passport.Password);
                result = apiFunc();
            }
            return result;
        }
    }
}
