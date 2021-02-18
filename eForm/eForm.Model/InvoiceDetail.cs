using System;
using System.Collections.Generic;
using System.Text;

namespace eForm.Model
{
    public class InvoiceDetail
    {
        public string RequestNumber { get; set; }
        public string DetailName { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public int UoMID { get; set; }

    }
}
