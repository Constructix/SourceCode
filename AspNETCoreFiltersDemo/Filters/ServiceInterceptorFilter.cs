using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNETCoreFiltersDemo.Filters
{
    public class ServiceInterceptorFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {

            var currentDate = DateTime.Now.ToString("O");
            var message = $"{currentDate} - On Action before Executing..... Controller - {context.Controller.ToString()}{Environment.NewLine}";
            System.IO.File.AppendAllText(@"AspNETFilters.txt", message);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var currentDate = DateTime.Now.ToString("O");
            var message = $"{currentDate} - Executed..... Controller - {context.Controller.ToString()}{Environment.NewLine}";
            System.IO.File.AppendAllText(@"AspNETFilters.txt", message);
        }
    }
}