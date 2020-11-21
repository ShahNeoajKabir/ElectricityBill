using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class Zone
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
