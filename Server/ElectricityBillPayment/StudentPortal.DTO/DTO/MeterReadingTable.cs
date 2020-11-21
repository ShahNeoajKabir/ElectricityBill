using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class MeterReadingTable
    {
        public int MeterReadingId { get; set; }
        public int MeterAssignId { get; set; }
        public int CustomerId { get; set; }
        public int MeterId { get; set; }
        public double CurrentUnit { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public virtual BillTable BillTable{get;set;}
        public virtual MeterAssign MeterAssign{get;set;}
    }
}
