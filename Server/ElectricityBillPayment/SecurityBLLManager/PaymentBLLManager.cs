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
    public class PaymentBLLManager: IPaymentBLLManager
    {
        private readonly DatabaseContext _database;
        public PaymentBLLManager(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<Payment>AddPayment( VMPayment vMPayment)
        {
            Payment payment = new Payment();
            try
            {
                
                var customer = await _database.Customer.Where(p => p.MobileNo == vMPayment.MobileNo).FirstOrDefaultAsync();
                var meter = await _database.MeterTable.Where(p => p.MeterNumber == vMPayment.MeterNumber).FirstOrDefaultAsync();
                if(customer!=null && meter != null)
                {
                    var res = await _database.BillTable.Where(p => p.CustomerId == customer.CustomerId && p.MeterId == meter.MeterId && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).FirstOrDefaultAsync();
                    _database.Database.BeginTransaction();
                    payment = new Payment()
                    {
                        BillId = res.BillId,
                        CustomerId = customer.CustomerId,
                        MeterId = meter.MeterId,
                        Status = res.Status,
                        PaymentMethod = payment.PaymentMethod,
                        CreatedBy = customer.CustomerName,
                        CreatedDate = DateTime.Now
                    };
                    await _database.Payment.AddAsync(payment);
                    await _database.SaveChangesAsync();
                    if (payment.PaymentMethod == 1)
                    {
                       
                        var check = await _database.CardInformation.Where(p => p.CardNumber == vMPayment.CardNumber && p.CVV == vMPayment.CVV).FirstOrDefaultAsync();
                        
                    }
                }
                return payment;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

    public interface IPaymentBLLManager
    {

    }
}
