using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.ViewModel
{
   public class VmPaymentHistory
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string CustomerName { get; set; }
        public int PaymentMethod { get; set; }
        public double UsageUnit { get; set; }
        public double LastBilledUnit { get; set; }
        public double PaidAmount { get; set; }
        public string MeterNumber { get; set; }
        public string PaymentDate { get; set; }
    }
}
