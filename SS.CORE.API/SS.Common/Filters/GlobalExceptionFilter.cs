using SS.Common.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SS.Common.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
            Log4NetHelper.WriteError(type, filterContext.Exception);
        }
    }
}
