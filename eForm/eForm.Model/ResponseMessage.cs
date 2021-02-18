using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace eForm.Model
{
    public class ResponseMessage<T>
    {
        public bool Success { get; set; }
        public ResponseStatus Status { get; set; }
        public string StatusText { get { return Status.ToString(); } }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        private int total;
        public int Total { get { return Data is IList && Data.GetType().IsGenericType ? ((IList)Data).Count : total; } set { total = value; } }
        public object ModelState { get; set; }
    }

    public enum ResponseStatus
    {
        Success,
        Confirm,
        Warning,
        Error
    }
}
