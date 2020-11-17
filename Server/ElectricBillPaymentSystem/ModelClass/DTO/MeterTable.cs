using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class MeterTable
    {
        public int MeterId { get; set; }
        public string MeterNumber { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public ICollection<MeterAssign> MeterAssign { get; set; }
        
    }
}
