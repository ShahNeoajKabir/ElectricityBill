using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class ZoneAssign
    {
        public int ZoneAssignId { get; set; }
        public int MeterReaderId { get; set; }
        public int ZoneId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
    }
}
