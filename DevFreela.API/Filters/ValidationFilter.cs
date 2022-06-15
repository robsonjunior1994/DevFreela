using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace DevFreela.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        //Executa depois da requisição
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new System.NotImplementedException();
        }

        //Executa antes da requisição
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                var messages = context.ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(messages);
            }
        }
    }
}
