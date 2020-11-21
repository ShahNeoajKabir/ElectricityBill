using Electricity.Common.Utility;
using Electricity.DAL;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class CustomerBLLManager : ICustomerBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public CustomerBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer AddCustomer(Customer customer)
        {
            try
            {
                customer.CreatedBy = "CoOrdinator";
                customer.CreatedDate = DateTime.Now;
                customer.Password = new EncryptionService().Encrypt(customer.Password);
                 _dbContext.Customer.Add(customer);
                _dbContext.SaveChanges();
                return customer;
            }
            catch (Exception)
            {

                throw new Exception("Failed To Registration");
            }
        }

        public List<Customer> GetAll()
        {
            List<Customer> customer = _dbContext.Customer.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToList();
            return customer;
        }

        public Customer GetById(Customer customer)
        {
            return _dbContext.Customer.Find(customer.CustomerId);
        }

        public Customer UpdateUser(Customer customer)
        {
            try
            {
                var res = _dbContext.Customer.Where(p => p.CustomerId == customer.CustomerId).FirstOrDefault();
                if (res != null)
                {
                    customer.UpdatedBy = "Customer";
                    customer.UpdatedDate = DateTime.Now;
                    _dbContext.Customer.Update(customer);
                     _dbContext.SaveChanges();
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
        Customer AddCustomer(Customer customer);
        List<Customer> GetAll();
        Customer GetById(Customer customer);
        Customer UpdateUser(Customer customer);
    }
}
