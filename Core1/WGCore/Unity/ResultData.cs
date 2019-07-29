using System;
using System.Collections.Generic;
using System.Text;

namespace Unity
{
    public class RestfulResult
    {
        public int Code { get; private set; }
        public string Message { get; private set; }
        public bool Success { get; private set; }
        public long Timestamp { get; }
        protected RestfulResult()
        {
            Timestamp = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }
        public static RestfulResult Succeed(string message = "成功")
        {
            return new RestfulResult()
            {
                Code = 200,
                Message = message,
                Success = true
            };
        }
        public static RestfulResult Fail(string message, int code = 500)
        {
            return new RestfulResult()
            {
                Code = code,
                Message = message,
                Success = false
            };
        }

        public static RestfulResult<T> Fail<T>(T Result, string message, int code = 500)
        {
            return new RestfulResult<T>()
            {
                Code = code,
                Message = message,
                Result = Result,
                Success = false
            };
        }

        public static RestfulResult<T> Succeed<T>(T Result, string message = "成功")
        {
            return new RestfulResult<T>()
            {
                Code = 200,
                Message = message,
                Result = Result,
                Success = true
            };
        }
    }
    public class RestfulResult<T> : RestfulResult
    {
        public RestfulResult() : base()
        {
        }
        public virtual T Result { get; set; }
    }
}
