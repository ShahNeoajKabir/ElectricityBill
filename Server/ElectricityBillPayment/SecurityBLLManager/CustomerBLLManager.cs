using Common.Electricity.Utility;
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
    public class CustomerBLLManager : ICustomerBLLManager
    {
        private readonly DatabaseContext _dbContext;
        public CustomerBLLManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            try
            {

                customer.Status = (int)Common.Electricity.Enum.Enum.Status.Pending;
                customer.Image = customer.Image;
                customer.CreatedBy = "Admin";
                customer.CreatedDate = DateTime.Now;
                customer.Password = new EncryptionService().Encrypt(customer.Password);
                await _dbContext.Customer.AddAsync(customer);
                await _dbContext.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {

                throw new Exception("Failed To Registration");
            }
        }
        public List<Customer> GetAllPendingCustomer(int userid)
        {
            List<Customer> customer = new List<Customer>();

            var zone = _dbContext.ZoneAssign.Where(p => p.UserId == userid && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).FirstOrDefault();
            if (zone != null)
            {
                customer = _dbContext.Customer.Where(p => p.ZoneId == zone.ZoneId && p.Status == (int)Common.Electricity.Enum.Enum.Status.Pending).ToList();

            }
            else
            {
                customer = _dbContext.Customer.Where(p=> p.Status == (int)Common.Electricity.Enum.Enum.Status.Pending).ToList();

            }
            return customer;
        }
        public Task<List<Customer>> GetAllPending()
        {
            Task<List<Customer>> customer = _dbContext.Customer.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Pending).ToListAsync();
            return customer;
        }

        public Task<List<Customer>> GetAll()
        {
            Task<List<Customer>> customer = _dbContext.Customer.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToListAsync();
            return customer;
        }

        public async Task<List<Customer>> Search(string CustomerName)
        {
            var search = await _dbContext.Customer.Where(c => c.CustomerName.Contains(CustomerName)).ToListAsync();
            return search;
        }

        public async Task<Customer> GetById(Customer customer)
        {
            var res = await _dbContext.Customer.Where(c => c.CustomerId == customer.CustomerId).FirstOrDefaultAsync();
            return res;
        }

        public async Task<Customer> UpdateUser(Customer customer)
        {
            try
            {
                var id = await _dbContext.Customer.Where(p => p.CustomerId == customer.CustomerId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    customer.UpdatedBy = "Customer";
                    customer.UpdatedDate = DateTime.Now;
                    _dbContext.Customer.Update(customer);
                    await _dbContext.SaveChangesAsync();
                }

                return customer;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CustomerLocation>> GetAllCustomerLocation()
        {
            var location = await _dbContext.Customer.Select(p => new CustomerLocation()
            {
                Latitude = p.Latitude,
                Longitude = p.Longitude
            }).ToListAsync();
            return location;
        }
    }


    public interface ICustomerBLLManager
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(Customer customer);
        Task<Customer> UpdateUser(Customer customer);
        Task<List<Customer>> Search(string CustomerName);
        List<Customer> GetAllPendingCustomer(int userid);
        Task<List<Customer>> GetAllPending();
        Task<List<CustomerLocation>> GetAllCustomerLocation();

    }
}
