using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFirmasi.MyNotes.WebApiService.Models
{
    public abstract class BaseResponse
    {
        public List<string> Errors { get; set; }
        public bool HasError { get; set; }
        public bool IsSuccessFul { get; set; }
    }
}
