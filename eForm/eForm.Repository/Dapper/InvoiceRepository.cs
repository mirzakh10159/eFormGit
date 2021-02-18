using System;
using System.Collections.Generic;
using System.Text;
using eForm.Model;
using eForm.Repository.Base;
using eForm.Repository.Interface;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Linq;
using eForm.Repository.SQLQuery;

namespace eForm.Repository.Dapper
{
    public class InvoiceRepository : BaseRepository, IInvoiceRepository
    {
        public InvoiceRepository(string connectionString) :
            base(connectionString)
        { }

        public InvoiceRepository(IConfiguration configuration) :
            base(configuration)
        { }

        public InvoiceHeader GetByRequestNumber(string requestNumber)
        {
            InvoiceHeader invHeader = new InvoiceHeader();
            try
            {
                List<InvoiceDetail> invDetail = new List<InvoiceDetail>();
                using (var connection = Connection)
                {
                    invHeader = connection.Query<InvoiceHeader>(InvoiceQuery.GetInvoiceHeader, new { RequestNumber = requestNumber }, commandTimeout: timeout).FirstOrDefault();
                    invDetail = connection.Query<InvoiceDetail>(InvoiceQuery.GetInvoiceDetail, new { RequestNumber = requestNumber }, commandTimeout: timeout).ToList();
                    invHeader.InvoiceDetail = invDetail;
                    return invHeader;
                }
            }
            catch
            {
                return null;
            }
        }

        public Response <InvoiceHeader> SaveInvoice(InvoiceHeader invoiceRequest)
        {
            var response = new Response<InvoiceHeader>();
            try
            {
                ExecuteTransaction(Connection, (connection, transaction) =>
                {
                    string generatedRequestNumber = GenerateRequestNumber(connection, transaction);
                    invoiceRequest.RequestNumber = generatedRequestNumber;
                    connection.Execute(InvoiceQuery.InsertInvoiceHeader, invoiceRequest, transaction, timeout);
                    foreach (var dt in invoiceRequest.InvoiceDetail)
                    {
                        dt.RequestNumber = generatedRequestNumber;
                        connection.Execute(InvoiceQuery.InsertInvoiceDetail, dt, transaction, timeout);
                    }
                    return null;
                });
                response.Success = true;
                response.Message = "Data has been saved sucessfully";
                response.Result = invoiceRequest;
            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error While Saving Data !" + ex.Message;
                response.ErrorMessage = ex.Message.ToString();
            }
            return response;
        }

        private string GenerateRequestNumber(IDbConnection connection, IDbTransaction transaction)
        {
            string TemplateNumber = "INV-" +  "-";
            return GetRunningNumber(connection, transaction, TemplateNumber);
        }

        private string GetRunningNumber(IDbConnection connection, IDbTransaction transaction, string ReqNumber)
        {
            string generatedReqNumber = ReqNumber;

            bool isExist = true;
            int returnCheck = 0;
            int currentNumber = -1;
            while (isExist)
            {
                generatedReqNumber = GenerateNumber(connection, transaction, ReqNumber, ref currentNumber);
                returnCheck = connection.Query<int>("SELECT COUNT(*) FROM InvoiceHeader WHERE RequestNumber = @ReqNumber ",
                                        new { ReqNumber = generatedReqNumber }, transaction, true, timeout).SingleOrDefault();
                if (returnCheck <= 0) { isExist = false; }
                else { currentNumber += 1; }
            }

            return generatedReqNumber;
        }
        private string GenerateNumber(IDbConnection connection, IDbTransaction transaction, string ReqNumber, ref int currentNumber)
        {
            string number = "";
            string ReturnStr = "";
            int num = 0;

            if (currentNumber < 0)
            {
                num = connection.Query<int>("SELECT ISNULL(MAX(CONVERT(INT, SUBSTRING(RequestNumber, LEN(RequestNumber) - 3, 4))), 0) FROM InvoiceHeader WHERE RequestNumber LIKE @Request + '%' AND LEN(RequestNumber) = 20",
                                            new { Request = ReqNumber }, transaction, true, timeout).SingleOrDefault();
                currentNumber = (num + 1);
            }

            number = "00000" + currentNumber.ToString();
            number = number.Substring(number.Length - 4);
            ReturnStr = ReqNumber + number;

            return ReturnStr;
        }

    }
}