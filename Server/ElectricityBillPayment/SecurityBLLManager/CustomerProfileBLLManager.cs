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

                
                var customer = _database.Customer.Where(p => p.UserId == UserId).FirstOrDefault();
                var meterassign = _database.MeterAssign.Where(p => p.CustomerId == customer.CustomerId && p.Status==(int)Common.Electricity.Enum.Enum.Status.Active).FirstOrDefault();
                var meter = _database.MeterTable.Where(p => p.MeterId == meterassign.MeterId).FirstOrDefault();
                VMProfile vMProfile = new VMProfile()
                {
                    CustomerId=customer.CustomerId,
                    CustomerName=customer.CustomerName,
                    Email=customer.Email,
                    Image=customer.Image,
                    MeterNumber=meter.MeterNumber,
                    MobileNo=customer.MobileNo,
                    ZoneName=_database.Zone.FirstOrDefault(p=>p.ZoneId==customer.ZoneId).ZoneName

                };
                return vMProfile;





            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<VMBillPaper> ViewBillPaper(int BillId)
        {
            var bill = await _database.BillTable.Where(p => p.BillId == BillId).FirstOrDefaultAsync();
            var customer = await _database.Customer.Where(p => p.CustomerId == bill.CustomerId).FirstOrDefaultAsync();
            var meter = await _database.MeterTable.Where(p => p.MeterId == bill.MeterId).FirstOrDefaultAsync();
            decimal vat = (decimal)(5 * bill.BillAmount) / 100;
            decimal BillAmount = (decimal)bill.BillAmount - vat;
            double UsesUnit = bill.CurrentUnit - bill.PreviousUnit;


            var ViewBillPaper = new VMBillPaper()
            {
                BillId = bill.BillId,
                CustomeName = customer.CustomerName,
                MeterNumber = meter.MeterNumber,
                BillAmount = BillAmount,
                CurrentUnit = bill.CurrentUnit.ToString(),
                PreviousUnit = bill.PreviousUnit.ToString(),
                Email = customer.Email,
                MobileNo=customer.MobileNo,
                TotalBillAmount = (decimal)bill.BillAmount,
                CreatedBy=bill.CreatedBy,
                CreatedDate=bill.CreatedDate,
                Vat = vat,
                CustomeId = customer.CustomerId,
                MeterId = meter.MeterId,
                UsesUnit = UsesUnit.ToString()

            };
            return ViewBillPaper;
        }
    }


    public interface ICustomerProfileBLLManager
    {
        Task<VMProfile> ViewProfile(int UserId);
        Task<VMBillPaper> ViewBillPaper(int BillId);
    }
}
