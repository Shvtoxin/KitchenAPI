using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Kitchen.Services.Contracts.Exceptions;

namespace Kitchen.API.Extensions
{
    /// <summary>
    /// Фильтр ошибок
    /// </summary>
    public class KitchenExceptionFilter : IExceptionFilter
    {
        /// <inheritdoc/>
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception as KitchenException;
            if (exception == null)
            {
                return;
            }

            switch (exception)
            {             
                case KitchenInvalidOperationException ex:
                    SetDataToContext(
                        new BadRequestObjectResult(new ApiExceptionDetail { Message = ex.Message, })
                        {
                            StatusCode = StatusCodes.Status406NotAcceptable,
                        },
                        context);
                    break;

                case KitchenNotFoundException ex:
                    SetDataToContext(new NotFoundObjectResult(new ApiExceptionDetail
                    {
                        Message = ex.Message,
                    }), context);
                    break;

                default:
                    SetDataToContext(new BadRequestObjectResult(new ApiExceptionDetail
                    {
                        Message = $"Ошибка записи в БД (Проверьте индексы). {exception.Message}",
                    }), context);
                    break;
            }
        }

        /// <summary>
        /// Определяет контекст ответа
        /// </summary>
        static protected void SetDataToContext(ObjectResult data, ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.StatusCode = data.StatusCode ?? StatusCodes.Status400BadRequest;
            context.Result = data;
        }
    }
}
