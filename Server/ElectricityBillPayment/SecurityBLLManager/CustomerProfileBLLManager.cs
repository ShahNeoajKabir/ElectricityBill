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
    public class CustomerProfileBLLManager: ICustomerProfileBLLManager
    {
        private readonly DatabaseContext _database;
        public CustomerProfileBLLManager(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<VMProfile>ViewProfile(int UserId)
        {
            try
            {
                var user = await _database.User.Where(p => p.UserId == UserId).FirstOrDefaultAsync();
                BillTable bill = new BillTable();
                var customer = await _database.Customer.Where(p => p.CustomerId == bill.CustomerId).FirstOrDefaultAsync();
                var meter = await _database.MeterTable.Where(p => p.MeterId == bill.MeterId).FirstOrDefaultAsync();
                var UsesUnit = bill.CurrentUnit - bill.PreviousUnit;
                var vmProfile = new VMProfile()
                {
                    CustomerName = customer.CustomerName,
                    MeterNumber = meter.MeterNumber,
                    CurrentUnit = bill.CurrentUnit.ToString(),
                    PreviousUnit = bill.PreviousUnit.ToString(),
                    UsesUnit = UsesUnit.ToString(),
                    Image = customer.Image,
                    MobileNo = customer.MobileNo,
                    TotalBillAmount = bill.BillAmount.ToString()

                };
                return vmProfile;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }


    public interface ICustomerProfileBLLManager
    {
        Task<VMProfile> ViewProfile(int UserId);
    }
}
