using Electricity.Common.Utility;
using Electricity.DAL;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class MeterAssignBLLmanager : IMeterAssignBLLmanager
    {

        private readonly PaymentDbContext _dbContext;
        public MeterAssignBLLmanager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public MeterAssign AssignMeter(MeterAssign meter)
        {
            try
            {
                var customer = _dbContext.Customer.Where(p => p.CustomerId == meter.CustomerId).FirstOrDefault();
                _dbContext.Database.BeginTransaction();
                if (customer != null)
                {
                    meter.CreatedBy = "CoOrdinator";
                    meter.CreatedDate = DateTime.Now;
                    _dbContext.MeterAssign.Add(meter);
                    _dbContext.SaveChanges();

                }
                else
                {
                    throw new Exception("Customer not Fount");
                }

                
                customer.UserId= addCustomerIntoUserTable(customer);

                _dbContext.Customer.Update(customer);
                _dbContext.Database.CommitTransaction();
                _dbContext.SaveChanges();
                return meter;
            }
            catch (Exception ex)
            {
                _dbContext.Database.RollbackTransaction();
                throw;
            }
        }

        public List<MeterAssign> GetAll()
        {
            List<MeterAssign> meter = _dbContext.MeterAssign.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).Select(t => new MeterAssign()
            {
                CreatedBy = t.CreatedBy,
                CreatedDate=t.CreatedDate,
                Status=t.Status,
                MeterTable=t.MeterTable,
                Customer=t.Customer,
                MeterId=t.MeterId,
                CustomerId=t.CustomerId
            }).ToList();
            return meter;

        }

        public MeterAssign UpdateAssign(MeterAssign meter)
        {
            try
            {
               
                    meter.UpdatedBy = "CoOrdinator";
                    meter.UpdatedDate = DateTime.Now;
                    _dbContext.MeterAssign.Update(meter);
                    _dbContext.SaveChanges();
                return meter;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public MeterAssign GetById(MeterAssign meter)
        {
            return _dbContext.MeterAssign.Find(meter.MeterAssignId);
        }

        private int addCustomerIntoUserTable(Customer customer)
        {
            int result = 0;
            User user = new User()
            {
                Email = customer.Email,
                Gender = customer.Gender,
                UserName = customer.CustomerName,
                Image = customer.Image,
                MobileNo = customer.MobileNo,
                Password = new EncryptionService().Encrypt("123456"),
                UserTypeId = (int)Electricity.Common.Enum.Enum.UserType.Customer,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                Status = (int)Electricity.Common.Enum.Enum.Status.Active

            };
            _dbContext.User.Add(user);
            var res = _dbContext.SaveChanges();
            if (res == 1)
            {
                result = user.UserId;
            }
            return result;

        }
    }

    public interface IMeterAssignBLLmanager
    {
        MeterAssign AssignMeter(MeterAssign meter);
        List<MeterAssign> GetAll();
        MeterAssign UpdateAssign(MeterAssign meter);
        MeterAssign GetById(MeterAssign meter);
    }
}
