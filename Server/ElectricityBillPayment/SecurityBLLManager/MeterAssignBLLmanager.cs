﻿using Common.Electricity.Utility;
using Context;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager
{
    public class MeterAssignBLLmanager : IMeterAssignBLLmanager
    {

        private readonly DatabaseContext _dbContext;
        
        public MeterAssignBLLmanager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<MeterAssign> AssignMeter(MeterAssign meter)
        {
            try
            {
                var customer = await _dbContext.Customer.Where(p => p.CustomerId == meter.CustomerId).FirstOrDefaultAsync();
                _dbContext.Database.BeginTransaction();
                if (customer != null && meter.MeterId>0 )
                {
                    meter.CreatedDate = DateTime.Now;
                    await _dbContext.MeterAssign.AddAsync(meter);
                    await _dbContext.SaveChangesAsync();

                }
                else
                {
                    throw new Exception("Customer not Found");
                }


                customer.UserId = addCustomerIntoUserTable(customer);
                customer.Status = (int)Common.Electricity.Enum.Enum.Status.Active;
                _dbContext.Customer.Update(customer);
                _dbContext.Database.CommitTransaction();
                _dbContext.SaveChanges();
                return meter;
            }
            catch (Exception ex)
            {
                _dbContext.Database.RollbackTransaction();
                throw new Exception("Something is wrong");
            }
        }
       

        public List<MeterAssign> GetAll(int userid)
        {
            List<MeterAssign> meter = new List<MeterAssign>();
            var zone = _dbContext.ZoneAssign.Where(p => p.UserId == userid && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).FirstOrDefault();
            if (zone != null)
            {
                var customerid = _dbContext.Customer.Where(p => p.ZoneId == zone.ZoneId && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(p => p.CustomerId).ToArray();
                 meter = _dbContext.MeterAssign.Where(p => customerid.Contains(p.CustomerId) && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(t => new MeterAssign()
                {
                    CreatedBy = t.CreatedBy,
                    CreatedDate = t.CreatedDate,
                    Status = t.Status,
                    MeterTable = t.MeterTable,
                    Customer = t.Customer,
                    MeterId = t.MeterId,
                    CustomerId = t.CustomerId,
                    MeterAssignId = t.MeterAssignId
                }).ToList();
            }
            else
            {
                meter = _dbContext.MeterAssign.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(t => new MeterAssign()
                {
                    CreatedBy = t.CreatedBy,
                    CreatedDate = t.CreatedDate,
                    Status = t.Status,
                    MeterTable = t.MeterTable,
                    Customer = t.Customer,
                    MeterId = t.MeterId,
                    CustomerId = t.CustomerId,
                    MeterAssignId = t.MeterAssignId
                }).ToList();
            }
            
            return meter;

        }

        public async Task<List<MeterAssign>> Search(string MeterNumber)
        {
            var search = await _dbContext.MeterAssign.Where(c => c.MeterTable.MeterNumber.Contains(MeterNumber)).ToListAsync();
            return search;
        }

        public async Task<MeterAssign> UpdateAssign(MeterAssign meter)
        {
            try
            {
                var id = await _dbContext.MeterAssign.Where(p => p.MeterAssignId == meter.MeterAssignId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    
                    meter.UpdatedDate = DateTime.Now;
                    _dbContext.MeterAssign.Update(meter);
                    await _dbContext.SaveChangesAsync();
                }


                return meter;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<MeterAssign> GetById(MeterAssign meter)
        {

            var res =await _dbContext.MeterAssign.Where(c => c.MeterAssignId == meter.MeterAssignId).FirstOrDefaultAsync();
            return res;
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
                UserTypeId = (int)Common.Electricity.Enum.Enum.UserType.Customer,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                Status = (int)Common.Electricity.Enum.Enum.Status.Active

            };

            _dbContext.User.Add(user);
            var res = _dbContext.SaveChanges();
            
            if (res == 1)
            {
                result = user.UserId;
                UserRole userRole = new UserRole()
                {
                    RoleId = 4,
                    UserId = user.UserId,
                    CreatedBy = "CoOrdinator",
                    CreatedDate = DateTime.Now
                };
                _dbContext.UserRole.Add(userRole);
                _dbContext.SaveChanges();
            }
            return result;

        }
    }

    public interface IMeterAssignBLLmanager
    {
        Task<MeterAssign> AssignMeter(MeterAssign meter);
        List<MeterAssign> GetAll(int userid);
        Task<MeterAssign> UpdateAssign(MeterAssign meter);
        Task<MeterAssign> GetById(MeterAssign meter);
        Task<List<MeterAssign>> Search(string MeterNumber);
    }
}
