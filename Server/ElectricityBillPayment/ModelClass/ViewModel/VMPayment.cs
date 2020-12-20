using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.ViewModel
{
    public class VMPayment
    {
        public string MeterNumber { get; set; }
        public string CustomeName { get; set; }
        public string Email { get; set; }
        public string CurrentUnit { get; set; }
        public decimal Vat { get; set; }
        public decimal TotalBillAmount { get; set; }
        public decimal BillAmount { get; set; }

    }
}
