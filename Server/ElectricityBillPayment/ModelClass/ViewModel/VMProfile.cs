using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.ViewModel
{
    public class VMProfile
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Image { get; set; }
       
        public string MeterNumber { get; set; }
        public string ZoneName { get; set; }
    }

    public class CustomerLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
