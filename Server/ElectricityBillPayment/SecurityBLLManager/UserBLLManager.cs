
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
                var uniqueemail = _db.User.Where(p => p.Email == user.Email).FirstOrDefault();

                if(user.Email!=null && user.UserName!=null && user.MobileNo!=null && user.UserTypeId>0)
                {
                    if (uniqueemail != null)
                    {
                        throw new Exception("");
                    }
                    else
                    {
                        user.CreatedDate = DateTime.Now;

                        user.Password = new EncryptionService().Encrypt(user.Password);


                        await _db.User.AddAsync(user);
                        await _db.SaveChangesAsync();

                    }
                    
                    
                    return user;
                }
                else
                {
                    throw new Exception("");
                    
                }
                
                
            }
            catch (Exception ex)
            {

                throw;
            }
            
            
        }
        public async Task<List<User>> Search(string UserName)
        {

            var search = await _db.User.Where(c => c.UserName.Contains(UserName)).ToListAsync();
            return search;
        }

        public async Task<List<VmUsers>> GetAll()
        {
            List<VmUsers> user =await _db.User.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(c=> new VmUsers() { 
            
            Email=c.Email,
            MobileNo=c.MobileNo,
            RoleName=c.UserRole.Where(p=>p.Status==1).FirstOrDefault().Role.RoleName,
            Status=c.Status,
            UserId=c.UserId,
            UserName=c.UserName
            
            }).ToListAsync();
            return user;
        }
        public List<User> GetAllUnAssignUser()
        {
            List<User> user = new List<User>();
            var userrolelist = _db.UserRole.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(c => c.UserId).ToArray();
            if (userrolelist.Length > 0)
            {
                user = _db.User.Where(p => !userrolelist.Contains(p.UserId)).ToList();

            }
            else
            {
                user = _db.User.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();

            }
            return user;
        }
        public List<User> GetAllMeterReader()
        {
            List<User> user = new List<User>();
            var meterassignLiost = _db.ZoneAssign.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(c => c.UserId).ToArray();
            if (meterassignLiost.Length > 0)
            {
                user = _db.User.Where(p => !meterassignLiost.Contains(p.UserId) &&  p.UserTypeId == 3).ToList();

            }
            else
            {
                user = _db.User.Where(p => p.UserTypeId == 3).ToList();

            }
            return user;
        }

        public async Task< User> UpdateUser(User user)
        {
            try
            {
                var id = await _db.User.Where(p => p.UserId == user.UserId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                var uniqueemail = _db.User.Where(p => p.Email == user.Email).AsNoTracking().FirstOrDefault();
                    if (uniqueemail != null)
                    {
                        throw new Exception("");
                    }
                    else
                    {
                        user.UpdatedDate = DateTime.Now;

                        _db.User.Update(user);
                        await _db.SaveChangesAsync(); 
                    }

                    

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
            var roleid = await _db.UserRole.Where(p => p.UserId == user && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).FirstOrDefaultAsync();
            if (roleid!= null)
            {
                res.Role = roleid.RoleId;
            }
            return res;
        }

        public async Task<bool> ChangePassword(VMChangePassword vMChangePassword)
        {
            var result = false;
            vMChangePassword.OldPassword = new EncryptionService().Encrypt(vMChangePassword.OldPassword);
            vMChangePassword.NewPassword = new EncryptionService().Encrypt(vMChangePassword.NewPassword);
            var user = await _db.User.Where(p => p.UserId ==Convert.ToInt32( vMChangePassword.UserId) && p.Email == vMChangePassword.Email && p.Password == vMChangePassword.OldPassword).AsNoTracking().FirstOrDefaultAsync();
            if (user != null)
            {
                user.Password = vMChangePassword.NewPassword;
                _db.User.Update(user);
                _db.SaveChanges();
                result = true;

            }
            return result;
        }
    }
    public interface IUserBLLManager
    {
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> GetByID(int user);

        Task<List<VmUsers>> GetAll();
        List<User> GetAllMeterReader();

        Task<List<User>> Search(string UserName);
        List<User> GetAllUnAssignUser();
        Task<Boolean> ChangePassword(VMChangePassword vMChangePassword);
    }
}
