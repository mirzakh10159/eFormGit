using eForm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace eForm.Repository.Interface
{
    public interface IInvoiceRepository
    {
        InvoiceHeader GetByRequestNumber(string requestNumber);
        Response <InvoiceHeader> SaveInvoice(InvoiceHeader data);

    }
}
