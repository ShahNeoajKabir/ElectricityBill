using System;
using System.Collections.Generic;
using System.Text;
namespace ModelClass.ViewModel
{
   public class JwtTokenSetting
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string ExpiresOn { get; set; }
    }
}
