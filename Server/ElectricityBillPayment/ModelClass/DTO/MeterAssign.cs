﻿using System;
using System.Collections.Generic;
using System.Text;
namespace ModelClass.DTO

{
    public class MeterAssign
    {
        public MeterAssign()
        {

        }
        public int MeterAssignId { get; set; }
        public int CustomerId { get; set; }
        public int MeterId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public  Customer Customer { get; set; }
        public  MeterTable MeterTable { get; set; }
        public ICollection<MeterReadingTable> MeterReadingTable{get;set;}
    }

    public class MeterAssignSearch
    {
        public string Search { get; set; }
    }
}
