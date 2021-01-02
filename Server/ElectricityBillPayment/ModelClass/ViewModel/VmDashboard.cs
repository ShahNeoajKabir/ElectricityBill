using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.ViewModel
{
    public class VmDashboard
    {
        public VmDashboard()
        {
            CustomerLocations = new List<CustomerLocation>();
            LastTenTransaction = new List<VmLastTenTransaction>();
        }
        public long TotalRegisteredCustomer { get; set; }
        public double TotalUsageUnit { get; set; }
        public long ActiveCustomer { get; set; }
        public double TotalBillAmount { get; set; }
        public double TotalBillCollectAmount { get; set; }
        public List<CustomerLocation> CustomerLocations { get; set; }
        public List<VmLastTenTransaction> LastTenTransaction { get; set; }
    }
}
