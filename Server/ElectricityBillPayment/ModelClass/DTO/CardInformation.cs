using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class CardInformation
    {
        public int CardInformationId { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string Pin { get; set; }
        public DateTime ExpiredDate { get; set; }
        public double Balance { get; set; }
        public int Status { get; set; }

    }
}
