using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.ViewModel
{
    public class VMBillPaper
    {
        public string MeterNumber { get; set; }
        public int MeterId { get; set; }
        public string CustomeName { get; set; }
        public int CustomeId { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string CurrentUnit { get; set; }
        public decimal Vat { get; set; }
        public decimal TotalBillAmount { get; set; }
        public decimal BillAmount { get; set; }
        public string PreviousUnit { get; set; }
        public string UsesUnit { get; set; }
        public int BillId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ZoneName { get; set; }

    }
}
