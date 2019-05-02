
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityExtensions
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var reuslt = context.Exception.Message;
        }
    }
}
