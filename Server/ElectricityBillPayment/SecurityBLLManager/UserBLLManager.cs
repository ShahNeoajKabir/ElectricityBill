
using Common.Electricity.Utility;
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
    public class UserBLLManager : IUserBLLManager
    {
        private readonly DatabaseContext _db;
        public UserBLLManager(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<User> AddUser(User user)
        {
            try
            {
                user.CreatedBy = "Admin";
                user.CreatedDate = DateTime.Now;

                user.Password = new EncryptionService().Encrypt(user.Password);

                await _db.User.AddAsync(user);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return user;
        }
        public async Task<List<User>> Search(string UserName)
        {

            var search = await _db.User.Where(c => c.UserName.Contains(UserName)).ToListAsync();
            return search;
        }

        public List<User> GetAll()
        {
            List<User> user = _db.User.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
            return user;
        }
        public List<User> GetAllMeterReader()
        {
            List<User> user = _db.User.Where(p => p.UserTypeId == 4).ToList();
            return user;
        }

        public async Task< User> UpdateUser(User user)
        {
            try
            {
                var id = await _db.User.Where(p => p.UserId == user.UserId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    user.UpdatedBy = "Admin";
                    user.UpdatedDate = DateTime.Now;

                    _db.User.Update(user);
                    await _db.SaveChangesAsync();

                }

                return user;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<User> GetByID(int user)
        {
            var res = await _db.User.Where(p => p.UserId == user).FirstOrDefaultAsync();
            return res;
        }
    }
    public interface IUserBLLManager
    {
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> GetByID(int user);

        List<User> GetAll();
        List<User> GetAllMeterReader();

        Task<List<User>> Search(string UserName);
    }
}
