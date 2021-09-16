using AFirmasi.MyNotes.Entities;
using AFirmasi.MyNotes.WebApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AFirmasi.MyNotes.WebApiService.Filters
{
    public class CategoryExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                HasError = true,
            };
            response.Errors.Add("Bir Hata Oluştu" + context.Exception.Message);

            context.Result = new BadRequestObjectResult(response);

        }
    }
}
