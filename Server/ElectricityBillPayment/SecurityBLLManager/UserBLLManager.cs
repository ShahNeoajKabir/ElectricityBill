
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ModelClass.DTO;
using Electricity.DAL;
using Electricity.Common.Utility;
using Microsoft.EntityFrameworkCore;

namespace SecurityBLLManager
{
    public class UserBLLManager : IUserBLLManager
    {
        private readonly PaymentDbContext _db;
        public UserBLLManager(PaymentDbContext db)
        {
            _db = db;
        }
        public User AddUser(User user)
        {
            user.CreatedBy = "Admin";
            user.CreatedDate = DateTime.Now;

            user.Password = new EncryptionService().Encrypt(user.Password);

            _db.User.Add(user);
            _db.SaveChanges();
            return user;
        }
        public List<User> Search(string UserName)
        {
            
            var search = _db.User.Where(c => c.UserName.Contains(UserName)).ToList();
            return search;
        }

        public async Task<List<User>> GetAll()
        {
            List<User> user = await _db.User.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToListAsync();
            return user;
        }

        public User UpdateUser(User user)
        {
            try
            {
                var id = _db.User.Where(p => p.UserId == user.UserId).AsNoTracking().FirstOrDefault();
                if (id != null)
                {
                    user.UpdatedBy = "Admin";
                    user.UpdatedDate = DateTime.Now;

                    _db.User.Update(user);
                    _db.SaveChanges();

                }

                return user;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public User GetByID(User user)
        {
            var res = _db.User.Where(p => p.UserId == user.UserId).FirstOrDefault();
            return res;
        }
    }
    public interface IUserBLLManager
    {
        User AddUser(User user);
        User UpdateUser(User user);
        User GetByID(User user);

        Task<List<User>> GetAll();

        List<User> Search(string UserName);
    }
}
