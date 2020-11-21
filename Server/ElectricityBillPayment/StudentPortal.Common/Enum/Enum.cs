﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Electricity.Common.Enum
{
  public  class Enum
    {
        public enum Gender {
        Male=1,
        Female=2
        }
        public enum Status
        {
            Active = 1,
            Inactive = 2,
            Delete=3
        }
        public enum UserType
        {
            Admin = 1,
            CoOrdinator = 2,
            MeterReader = 3,
            Customer = 4,
            SuperAdmin = -1
        }
        public enum CustomerType
        {
            Business = 1,
            Economi = 2,
            House = 3
        }
        public enum Religion
        {
            Muslim = 1,
            Hindhu = 2,
            Cristian = 3,
            Budho=4
        }
    }
}
