using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class MobileBanking
    {
        public int MobileBankingId { get; set; }
        public int MobileBankingType { get; set; }
        public string MobileNo { get; set; }
        public double Balance { get; set; }
        public string Pin { get; set; }
        public int Status { get; set; }
    }
}
