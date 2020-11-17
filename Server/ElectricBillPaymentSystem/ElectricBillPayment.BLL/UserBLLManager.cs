using Context;
using ElectricBillPayment.Common.Utility;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectricBillPayment.BLL
{
   public class UserBLLManager: IUserBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public UserBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }  

        public async Task<User> AddUser(User user)
        { 
            try
            {
                user.CreatedBy = "Admin";
                user.UpdatedDate = DateTime.Now;
                user.Status = (int)ElectricBillPayment.Common.Enum.Enum.Status.Active;
                user.Password = new EncryptionService().Encrypt(user.Password);
                await _dbContext.User.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return user;

            }
            catch (Exception ex)
            {
               
                throw;
            }

        }

        public async Task<List<User>> GetAll()
        {
            List<User> user = await _dbContext.User.Where(p => p.Status == (int)ElectricBillPayment.Common.Enum.Enum.Status.Active).ToListAsync();
            return user;
        }

        public User GetById(User user)
        {
            return _dbContext.User.Find(user.UserId);
            
        }


        public async Task<User> UpdateUser(User user)
        {
            try
            {
                var res = await _dbContext.User.Where(e => e.UserId == user.UserId).FirstOrDefaultAsync();
                if (res != null)
                {
                    user.UpdatedBy = "Admin";
                    user.UpdatedDate = DateTime.Now;
                    _dbContext.User.Update(user);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User Not Found");
                }
                
                return user;

            }
            catch (Exception ex)
            {
               
                throw;
            }
        }
    }


    public interface IUserBLLManager
    {
        Task<User> AddUser(User user);
        Task<List<User>> GetAll();
        User GetById(User user);
        Task<User> UpdateUser(User user);
    }
}
