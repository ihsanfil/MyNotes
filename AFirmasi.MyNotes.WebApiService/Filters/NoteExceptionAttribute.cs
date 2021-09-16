using AFirmasi.MyNotes.Entities;
using AFirmasi.MyNotes.WebApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFirmasi.MyNotes.WebApiService.Filters
{
    public class NoteExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>
            {
                HasError = true,
            };
            response.Errors.Add("Bir Hata Oluştu" + context.Exception.Message);

            context.Result = new BadRequestObjectResult(response);         
        }
    }
}
