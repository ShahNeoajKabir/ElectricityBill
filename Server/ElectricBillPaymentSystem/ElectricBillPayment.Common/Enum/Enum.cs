using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricBillPayment.Common.Enum
{
    public class Enum
    {
        public enum Gender
        {
            Male = 1,
            Female = 2
        }
        public enum Status
        {
            Active = 1,
            Inactive = 2,
            Delete = 3
        }

        public enum UserType
        {
            Admin = 1,
            CoOrdinator = 2,
            Consumer = 3,
            MeterReader = 4

        }
    }
}
