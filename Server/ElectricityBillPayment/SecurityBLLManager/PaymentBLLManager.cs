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
    public class PaymentBLLManager : IPaymentBLLManager
    {
        private readonly DatabaseContext _database;
        public PaymentBLLManager(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<Payment> MakePayment(VMMakePayment makePayment)
        {
            Payment payment = new Payment();
            try
            {
                var bill = _database.BillTable.Where(p => p.BillId == makePayment.BillId).AsNoTracking().FirstOrDefault();
                _database.Database.BeginTransaction();
                payment = new Payment()
                {
                    BillId = makePayment.BillId,
                    CustomerId = bill.CustomerId,
                    MeterId = bill.MeterId,
                    Status = (int)Common.Electricity.Enum.Enum.Status.Active,
                    PaymentMethod = makePayment.PaymentMethod,
                    CreatedBy = "Customer",
                    CreatedDate = DateTime.Now,

                };
                await _database.Payment.AddAsync(payment);
                await _database.SaveChangesAsync();

                if (payment.PaymentId > 1)
                {

                    bill.BillStatus = (int)Common.Electricity.Enum.Enum.BillStatus.Paid;
                    _database.BillTable.Update(bill);
                    _database.SaveChanges();

                }
                _database.Database.CommitTransaction();

                return payment;
            }
            catch (Exception ex)
            {
                _database.Database.RollbackTransaction();
                throw;
            }
        }

        public async Task<VMPayment> ViewPayment(int BillId)
        {
            var bill = await _database.BillTable.Where(p => p.BillId == BillId).FirstOrDefaultAsync();
            var customer = await _database.Customer.Where(p => p.CustomerId == bill.CustomerId).FirstOrDefaultAsync();
            var meter = await _database.MeterTable.Where(p => p.MeterId == bill.MeterId).FirstOrDefaultAsync();
            decimal vat = (decimal)(5 * bill.BillAmount) / 100;
            decimal BillAmount = (decimal)bill.BillAmount - vat;
            double UsesUnit = bill.CurrentUnit - bill.PreviousUnit;


            var vmpayment = new VMPayment()
            {
                BillId = bill.BillId,
                CustomeName = customer.CustomerName,
                MeterNumber = meter.MeterNumber,
                BillAmount = BillAmount,
                CurrentUnit = bill.CurrentUnit.ToString(),
                PreviousUnit = bill.PreviousUnit.ToString(),
                Email = customer.Email,
                TotalBillAmount = (decimal)bill.BillAmount,
                Vat = vat,
                CustomeId = customer.CustomerId,
                MeterId = meter.MeterId,
                UsesUnit = UsesUnit.ToString()

            };
            return vmpayment;
        }

        public async Task<List<VmPaymentHistory>> GetAll(int userid)
        {
            List<VmPaymentHistory> vmPaymentHistories = new List<VmPaymentHistory>();
            var customer = _database.Customer.Where(p => p.UserId == userid).FirstOrDefault();
            if (customer != null)
            {
                var meterAssign = _database.MeterAssign.Where(p => p.CustomerId == customer.CustomerId && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).FirstOrDefault();
                var meternumber = _database.MeterTable.FirstOrDefault(p => p.MeterId == meterAssign.MeterId);
                vmPaymentHistories = await _database.Payment.Where(p => p.CustomerId == customer.CustomerId).Select(c => new VmPaymentHistory()
                {
                    PaidAmount = _database.BillTable.FirstOrDefault(p => p.BillId == c.BillId).BillAmount,
                    CustomerName = customer.CustomerName,
                    LastBilledUnit = _database.BillTable.FirstOrDefault(p => p.BillId == c.BillId).CurrentUnit,
                    PaymentMethod = c.PaymentMethod,
                    MeterNumber = meternumber.MeterNumber,
                    Month = _database.BillTable.FirstOrDefault(p => p.BillId == c.BillId).CurrentMonth,
                    Year = _database.BillTable.FirstOrDefault(p => p.BillId == c.BillId).Year,
                    UsageUnit = _database.BillTable.FirstOrDefault(p => p.BillId == c.BillId).CurrentUnit - _database.BillTable.FirstOrDefault(p => p.BillId == c.BillId).PreviousUnit,
                    PaymentDate = c.CreatedDate.ToString("yyyy-MMMM-dd HH:mm")
                }).ToListAsync();
            }
            else
            {
                vmPaymentHistories =await _database.Payment.Select(c => new VmPaymentHistory()
                {
                    PaidAmount = _database.BillTable.FirstOrDefault(p => p.BillId == c.BillId).BillAmount,
                    CustomerName = _database.Customer.Where(p => p.CustomerId == c.CustomerId).FirstOrDefault().CustomerName,
                    LastBilledUnit = _database.BillTable.FirstOrDefault(p => p.BillId == c.BillId).CurrentUnit,
                    PaymentMethod = c.PaymentMethod,
                    MeterNumber = _database.BillTable.FirstOrDefault(p=>p.BillId==c.BillId).MeterNumber,
                    Month = _database.BillTable.FirstOrDefault(p => p.BillId == c.BillId).CurrentMonth,
                    Year = _database.BillTable.FirstOrDefault(p => p.BillId == c.BillId).Year,
                    UsageUnit = _database.BillTable.FirstOrDefault(p => p.BillId == c.BillId).CurrentUnit - _database.BillTable.FirstOrDefault(p => p.BillId == c.BillId).PreviousUnit,
                    PaymentDate = c.CreatedDate.ToString("yyyy-MMMM-dd HH:mm")
                }).ToListAsync();
            }

            return vmPaymentHistories;


        }
    }

    public interface IPaymentBLLManager
    {
        Task<Payment> MakePayment(VMMakePayment makePayment);
        Task<VMPayment> ViewPayment(int BillId);
        Task<List<VmPaymentHistory>> GetAll(int userid);
    }
}
