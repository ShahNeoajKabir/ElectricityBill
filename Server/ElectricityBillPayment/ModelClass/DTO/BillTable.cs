using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClass.DTO
{
    public class BillTable
    {
        public int BillId { get; set; }
        public int MeterReadingId { get; set; }
        public int CustomerId { get; set; }
        public int MeterId { get; set; }
        public double PreviousUnit { get; set; }
        public double CurrentUnit { get; set; }
        public double BillAmount { get; set; }
        public int CurrentMonth { get; set; }
        public int PreviousMonth { get; set; }
        public int Year { get; set; }
        public int BillStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        [NotMapped]
        public string CustomerName { get; set; }
        [NotMapped]

        public string MeterNumber { get; set; }

        public  MeterReadingTable MeterReadingTable { get; set; }
        public  Payment Payment { get; set; }
    }

    public class BillTableSearch
    {
        public string Search { get; set; }
    }
}
