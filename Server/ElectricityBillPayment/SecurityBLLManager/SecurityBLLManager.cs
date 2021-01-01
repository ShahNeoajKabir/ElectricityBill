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
    public class SecurityBLLManager : ISecurityBLLmanager
    {
        private readonly DatabaseContext _dbContext;
        public SecurityBLLManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> Login(VMLogin vMLogin)
        {
            User objuser = new User();
            try
            {
                vMLogin.Password = new EncryptionService().Encrypt(vMLogin.Password);
                objuser =await _dbContext.User.Where(p => p.Email == vMLogin.Email && p.Password == vMLogin.Password).AsNoTracking().Select(u => new User()
                {
                    UserTypeId = u.UserTypeId,
                    Email = u.Email,
                    UserId=u.UserId,
                    UserName=u.UserName,
                    UserRole=u.UserRole,
                    Gender=u.Gender,
                    MobileNo=u.MobileNo,
                    Image=u.Image,
                    Password=u.Password,
                    Status=u.Status,
                    UpdatedBy=u.UpdatedBy,
                    UpdatedDate=u.UpdatedDate,
                    UserTypeName=u.UserTypeName,
                    CreatedBy=u.CreatedBy,
                    CreatedDate=u.CreatedDate
                }).FirstOrDefaultAsync();
                var Role = _dbContext.UserRole.Where(p => p.UserId == objuser.UserId && p.Status == 1).AsNoTracking().FirstOrDefault();
                if (Role != null)
                {
                    objuser.Role = Role.RoleId;
                }
                else
                {
                    throw new Exception("You are not assign to any role");
                }


            }
            catch (Exception ex)
            {


            }
            return objuser;
        }
    }

    public interface ISecurityBLLmanager
    {
        Task<User> Login(VMLogin vMLogin);

    }
}
