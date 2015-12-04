using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Xp.Weixin.MP.Common;

namespace Xp.Weixin.MP.SDK.Api
{
    /// <summary>
    /// API操作容器（每次构造都会获取当前缓存中最新的Passport）
    /// </summary>
    public class ApiContainer
    {
        public Passport Passport { get; set; }

        public FriendApi FriendApi { get; set; }
        public MediaApi MediaApi { get; set; }
        public MessageApi MessageApi { get; set; }
        
        public ApiContainer(string userName, string password)
        {
            var passportBag = SdkManager.GetPassportBag(userName);
            if (passportBag == null || passportBag.Passport == null)
            {
                SdkManager.ApplyPassport(userName, password);
            }

            Passport = SdkManager.GetPassportBag(userName).Passport;//执行SdkManager.ApplyPassport后，PassportCollection[userName]必定存在

            FriendApi = new FriendApi(Passport);
            MessageApi = new MessageApi(Passport);
            MediaApi = new MediaApi(Passport);
        }
    }
}
