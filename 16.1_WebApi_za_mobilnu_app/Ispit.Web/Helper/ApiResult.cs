using System;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.Web.Helper
{
    public class ApiResult<T> 
    {
        public String exceptionMessage = "";
        public bool isException = false;
        public int exceptionCode = 0;
        public T value;

        public static ApiResult<T> Error(int exceptionCode, string exceptionMessage)
        {
            return new ApiResult<T>
            {
                isException = true,
                exceptionCode = exceptionCode,
                exceptionMessage = exceptionMessage
            };
        }
        public static ApiResult<T> OK(T value)
        {
            return new ApiResult<T>
            {
                isException = false,
                value = value
            };
        }

       
    }

}