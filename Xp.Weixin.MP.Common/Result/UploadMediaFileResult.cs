using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xp.Weixin.MP.Common
{
    /// <summary>
    /// 上传媒体文件返回结果(高级接口)
    /// </summary>
    public class UploadMediaFileResult
    {
        public UploadMediaFileType type { get; set; }
        public string media_id { get; set; }
        public long created_at { get; set; }
    }
}
