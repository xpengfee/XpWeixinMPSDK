using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xp.Weixin.MP.Common
{
    /// <summary>
    /// 上传媒体文件返回结果
    /// </summary>
    public class UploadResultJson : WxJsonResult
    {
       public UploadMediaFileType type { get; set; }
       public string media_id { get; set; }
       public string thumb_media_id { get; set; } // 上传缩略图返回的meidia_id参数.
       public long created_at { get; set; }
    }
}
