using System;
using System.Collections.Generic;
using System.Text;

namespace eForm.Model
{
    public class InvoiceHeader
    {
        public string RequestNumber { get; set; }
        public int LanguageID { get; set; }
        public int CurrencyID { get; set; }
        public string InvoiceFrom { get; set; }
        public int VendorID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Status { get; set; }
        public string PoNumber { get; set; }
        public decimal Discount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public List<InvoiceDetail> InvoiceDetail { get; set; }
    }
}
