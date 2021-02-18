using System;
using System.Collections.Generic;
using System.Text;

namespace eForm.Model
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
