using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Electricity.Enum
{
  public  class Enum
    {
        public enum Gender {
        Male=1,
        Female=2
        }
        public enum Month
        {
             January= 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }
        public enum year
        {
            
        }
        public enum BillStatus
        {
            Paid = 2,
            UnPaid = 1
        }
        public enum MobileBankingType
        {
            Bkash = 1,
            Rocket = 2
        }
        public enum PaymentMethod
        {
            Card=1,
            BKash=2,
            Rocket=3
        }

        public enum Blood
        {
            A = 1,
            B = 2,
            AB=3,
            O=4
        }
        public enum Mationality
        {
            Bangladesh=1,
            India=2,
            Pakistan=3,
            America=4,
            England
        }
        public enum Status
        {
            Active = 1,
            Inactive = 2,
            Delete=3,
            Pending=4
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


        public enum ErrorCode
        {
            INTERNAL_SERVER_ERROR = 500,
            BAD_REQUEST = 400,
            NOT_FOUND = 404,
            UNAUTHENTICATE = 401,
            UNAUTHORIZED = 403,
            TOKEN_EXPIRED = 402,
            SESSION_EXPIRED = 419,
            MISSING_TOKEN = 417,
            INVALID_TOKEN_FORMAT = 406
        }
    }
}
