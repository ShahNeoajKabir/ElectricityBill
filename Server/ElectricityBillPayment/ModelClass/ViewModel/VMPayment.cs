using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.ViewModel
{
    public class VMPayment
    {
        public string MeterNumber { get; set; }
        public int MeterId { get; set; }
        public string CustomeName { get; set; }
        public int CustomeId { get; set; }
        public string Email { get; set; }
        public string CurrentUnit { get; set; }
        public decimal Vat { get; set; }
        public decimal TotalBillAmount { get; set; }
        public decimal BillAmount { get; set; }
        public string PreviousUnit { get; set; }
        public string UsesUnit { get; set; }

    }

    public class VMMakePayment
    {
        public int BillId { get; set; }
        public int CustomerId { get; set; }
        public int MeterId { get; set; }
        public int PaymentMethod { get; set; }
        public CardInformation cardInformation { get; set; }
        public MobileBanking mobileBanking { get; set; }
        public decimal RequestAmount { get; set; }
    }
}
