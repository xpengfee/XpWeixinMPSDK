using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Xp.Weixin.MP.Common
{
    public interface IResult<T> where T : IResultData
    {
        ResultKind Ret { get; set; }
        string ErrorMessage { get; set; }
        T Data { get; set; }
        long RunTime { get; set; }
    }

    public interface IResultData
    {
    }

    public class ResultData : IResultData
    {

    }

    /// <summary>
    /// JSON返回结果
    /// </summary>
    public class Result<T> : IResult<T> where T : IResultData
    {
        public ResultKind Ret { get; set; }
        /// <summary>
        /// 如果结果未成功，则Data为期望的类型
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 错误信息，如果结果为成功，错误信息为Null
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Api执行时间
        /// </summary>
        public long RunTime { get; set; }
        //public T SData
        //{
        //    get { return Data as T; }
        //}
    }
}
