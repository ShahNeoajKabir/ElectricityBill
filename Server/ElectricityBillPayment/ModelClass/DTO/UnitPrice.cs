using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
   public class UnitPrice
    {
        public int UnitPriceId { get; set; }
        public int CustomerType { get; set; }
        public double UnitperPrice { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
    }
    public class UnitPriceSearch
    {
        public int search { get; set; }
    }
}
