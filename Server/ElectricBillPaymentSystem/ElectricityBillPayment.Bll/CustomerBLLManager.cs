
using Contextt;
using ElectricBillPayment.Common.Utility;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillPayment.Bll
{
    public class CustomerBLLManager: ICustomerBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public CustomerBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer>AddCustomer(Customer customer)
        {
            try
            {
                customer.CreatedBy = "CoOrdinator";
                customer.CreatedDate = DateTime.Now;
                customer.Status = (int)ElectricBillPayment.Common.Enum.Enum.Status.Active;
                customer.Password = new EncryptionService().Encrypt(customer.Password);
                await _dbContext.Customer.AddAsync(customer);
                await _dbContext.SaveChangesAsync();
                return customer;
            }
            catch (Exception)
            {

                throw new Exception("Failed To Registration");
            }
        }

        public async Task<List<Customer>> GetAll()
        {
            List<Customer> customer = await _dbContext.Customer.Where(p => p.Status == (int)ElectricBillPayment.Common.Enum.Enum.Status.Active).ToListAsync();
            return customer;
        }

        public Customer GetById(Customer customer)
        {
            return _dbContext.Customer.Find(customer.CustomerId);
        }

        public async Task<Customer>UpdateUser(Customer customer)
        {
            try
            {
                var res = await _dbContext.Customer.Where(p => p.CustomerId == customer.CustomerId).FirstOrDefaultAsync();
                if (res != null)
                {
                    customer.UpdatedBy = "Customer";
                    customer.UpdatedDate = DateTime.Now;
                    _dbContext.Customer.Update(customer);
                    await _dbContext.SaveChangesAsync();
                    return customer;
                }

                else
                {
                    throw new Exception("Failed To Update");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


    public interface ICustomerBLLManager
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<List<Customer>> GetAll();
        Customer GetById(Customer customer);
        Task<Customer> UpdateUser(Customer customer);
    }
}
