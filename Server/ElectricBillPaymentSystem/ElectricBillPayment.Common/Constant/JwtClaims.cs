using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricBillPayment.Common.Constant
{
    public class JwtClaims
    {
        public const string UserId = "UserId";
        public const string UserName = "UserName";
        public const string Email = "Email";
        public const string ExpiresDate = "ExpiresDate";
        public const string AccessRight = "user_type";
        public const string UniqueName = "unique_name";
    }
}
