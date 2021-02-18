using eForm.Api.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eForm.Repository;
using eForm.Repository.Interface;
using eForm.Model;
using Microsoft.AspNetCore.Http;
using System.Collections;

namespace eForm.Api.Controllers
{
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceRepository _repo;
        public InvoiceController(IInvoiceRepository repo, BaseControllerConfiguration config)
            : base(config)
        {
            _repo = repo;
        }

        [HttpPost]
        [Route("invoice/submit")]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<JsonResult> Submit(InvoiceHeader data)
        {
            ResponseMessage<object> response = new ResponseMessage<object>();
            try
            {
                 if (data != null)
                 {
                    var dbResult = _repo.SaveInvoice(data);
                    if (dbResult.Success)
                    {
                        response.Success = true;
                        response.Status = ResponseStatus.Success;
                        response.Data = dbResult.Result.RequestNumber;
                        response.Message = "Your Request Number : " + dbResult.Result.RequestNumber;
                    }
                }
                if (!response.Success)
                {
                    return new JsonResult(response);
                }
            }
            catch (Exception ex)
            {
                response = new ResponseMessage<object>
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Status = ResponseStatus.Error,
                    Message = "Failed while saving data. " + ex.Message
                };
            }

            response.Message = response.Success ? (response.Message + "<br /> Request Number: " + data.RequestNumber) : response.Message;
            response.Data = data.RequestNumber;
            return new JsonResult(response);
        }

        [Route("invoice/GetDataByInvoiceNumber")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDataByInvoiceNumber(string invoiceNumber)
        {
            InvoiceHeader dataInvoice = new InvoiceHeader();
            dataInvoice = _repo.GetByRequestNumber(invoiceNumber);
            return new OkObjectResult(dataInvoice);
        }


    }
}
