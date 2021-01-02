using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.ViewModel
{
    public class VmLastTenTransaction
    {
        public string imageurl { get; set; }
        public string CustomerName { get; set; }
        public double BilledUnit { get; set; }
        public int PaymentMethod { get; set; }
        public double PaidAmount { get; set; }
        public DateTime BillPaidDate { get; set; }
        public string ZoneName { get; set; }
    }
}
