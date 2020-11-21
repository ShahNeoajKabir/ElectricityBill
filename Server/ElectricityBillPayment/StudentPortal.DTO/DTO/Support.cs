using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class Support
    {
        public int SupportId { get; set; }
        public string SupportContent { get; set; }
        public string SupportSubject { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
    }
}
