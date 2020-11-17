using Context;
using ElectricBillPayment.Common.Utility;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricBillPayment.BLL
{
   public class CustomerBllManager: ICustomerBllManager
    {
        private readonly PaymentDbContext _dbContext;
        public CustomerBllManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Customer AddCustomer(Customer customer)
        {
            try
            {
                _dbContext.Database.BeginTransaction();
                customer.CreatedBy = "CoOrdinator";
                customer.CreatedDate = DateTime.Now;
                customer.Status = (int)ElectricBillPayment.Common.Enum.Enum.Status.Active;
                customer.Password = new EncryptionService().Encrypt(customer.Password);
                _dbContext.Customer.Add(customer);
                _dbContext.SaveChanges();


                User user = new User()
                {
                    UserName = customer.CustomerName,
                    Email = customer.Email,
                    Password = customer.Password,
                    MobileNo = customer.MobileNo,
                    CreatedBy = customer.CreatedBy,
                    CreatedDate = customer.CreatedDate,
                    Status = (int)ElectricBillPayment.Common.Enum.Enum.Status.Active,
                    UserTypeId = (int)ElectricBillPayment.Common.Enum.Enum.UserType.Consumer
                };
                _dbContext.User.Add(user);
                _dbContext.SaveChanges();
                _dbContext.Database.CommitTransaction();
                return customer;
                
                

            }
            catch (Exception)
            {
                _dbContext.Database.RollbackTransaction();
                throw new Exception("Customer Assign Failed");
            }
            
        }

        public List<Customer> GetAll()
        {
            List<Customer> customer = _dbContext.Customer.Where(p => p.Status == (int)ElectricBillPayment.Common.Enum.Enum.Status.Active).ToList();
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            try
            {
                var res = _dbContext.Customer.Where(p => p.CustomerId == customer.CustomerId).FirstOrDefault();
                if (res != null)
                {
                    customer.UpdatedBy = "CoOrdinator";
                    customer.UpdatedDate = DateTime.Now;
                    _dbContext.Customer.Update(customer);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Customer Not Found");
                }
                return customer;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public Customer GetById(Customer customer)
        {
            return _dbContext.Customer.Find(customer.CustomerId);
        }
    }


    public interface ICustomerBllManager
    {
        Customer AddCustomer(Customer customer);
        List<Customer> GetAll();
        Customer UpdateCustomer(Customer customer);
        Customer GetById(Customer customer);

    }
}
