using Context;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using ModelClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager
{
    public class DashboardBLLManager : IDashboardBLLManager
    {
        private readonly DatabaseContext _dbContext;

        public DashboardBLLManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<long> ActiveCustomer()
        {
            var count =await _dbContext.Customer.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).CountAsync();
            return count;
        }

        public async Task<List<CustomerLocation>> CustomerLocations()
        {
            var location = await _dbContext.Customer.Select(p => new CustomerLocation()
            {
                Latitude = p.Latitude,
                Longitude = p.Longitude
            }).ToListAsync();
            return location;
        }

        public async Task<List<VmLastTenTransaction>> LastTenTransaction()
        {
            var result =await _dbContext.BillTable
                .Where(p => p.BillStatus == (int)Common.Electricity.Enum.Enum.BillStatus.Paid)
                .Select(c => new VmLastTenTransaction()
                {
                    CustomerName=_dbContext.Customer.FirstOrDefault(p=>p.CustomerId==c.CustomerId).CustomerName,
                    BilledUnit=c.CurrentUnit-c.PreviousUnit,
                    PaidAmount=c.BillAmount,
                    imageurl= _dbContext.Customer.FirstOrDefault(p => p.CustomerId == c.CustomerId).Image,
                    PaymentMethod=_dbContext.Payment.FirstOrDefault(p=>p.BillId==c.BillId).PaymentMethod,
                    BillPaidDate= _dbContext.Payment.FirstOrDefault(p => p.BillId == c.BillId).CreatedDate,
                    ZoneName=_dbContext.Zone.Where(p=>p.ZoneId== (_dbContext.Customer.Where(p => p.CustomerId == c.CustomerId).Select(c=>c.ZoneId).FirstOrDefault())).FirstOrDefault().ZoneName

                }).OrderByDescending(p=>p.BillPaidDate).Take(10).ToListAsync();

            return result;
        }

        public async Task<double> TotalBillAmount()
        {
            var totalBill = await _dbContext.BillTable.SumAsync(p => p.BillAmount);
            return totalBill;
        }

        public async Task<double> TotalBillCollectAmount()
        {
            var totalBill =await _dbContext.BillTable.Where(p => p.BillStatus == (int)Common.Electricity.Enum.Enum.BillStatus.Paid).SumAsync(c => c.BillAmount);
            return totalBill;
        }
        public async Task<long> ToTalFemale()
        {
            var female = await _dbContext.Customer.Where(p => p.Gender == (int)Common.Electricity.Enum.Enum.Gender.Female).CountAsync();
            return female;
        }
        public async Task<long> ToTalMale()
        {
            var male = await _dbContext.Customer.Where(p => p.Gender == (int)Common.Electricity.Enum.Enum.Gender.Male).CountAsync();
            return male;
        }


        public async Task<long> TotalRegisteredCustomer()
        {
            var count =await _dbContext.Customer.CountAsync();
            return count;
        }

        public async Task<double> TotalUsageUnit()
        {
            var usage =await _dbContext.BillTable.SumAsync(p => p.CurrentUnit - p.PreviousUnit);
            return usage;
        }
        public async Task<List<MeterTable>> Meter()
        {
            return (await _dbContext.MeterTable.ToListAsync());
        }
    }

    public interface IDashboardBLLManager
    {
        Task<long> TotalRegisteredCustomer();
        Task<double> TotalUsageUnit();
        Task<long> ActiveCustomer();
        Task<double> TotalBillAmount();
        Task<double> TotalBillCollectAmount();
        Task<List<CustomerLocation>> CustomerLocations();
        Task<List<VmLastTenTransaction>> LastTenTransaction();
        Task<long> ToTalFemale();
        Task<long> ToTalMale();
        Task<List<MeterTable>>Meter();
    }
}
