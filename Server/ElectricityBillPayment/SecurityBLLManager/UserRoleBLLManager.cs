using Electricity.DAL;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class UserRoleBLLManager: IUserRoleBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public UserRoleBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public UserRole AddUserRole(UserRole userRole)
        {
            try
            {
                userRole.CreatedBy = "Admin";
                userRole.CreatedDate = DateTime.Now;
                _dbContext.UserRole.Add(userRole);
                _dbContext.SaveChanges();
                return userRole;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public List<UserRole> GetAll()
        {
            List<UserRole> userRole = _dbContext.UserRole.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).Select(t=>new UserRole()
            {
                CreatedBy=t.CreatedBy,
                CreatedDate=t.CreatedDate,
                Status=t.Status,
                User=t.User,
                Role=t.Role,
                UserId=t.UserId,
                RoleId=t.RoleId,
                UserRoleId=t.UserRoleId
            }).ToList();
            return userRole;
        }

        public List<UserRole> Search(string UserName)
        {
            var search = _dbContext.UserRole.Where(c => c.User.UserName.Contains(UserName)).ToList();
            return search;
        }


        public UserRole UpdateUserRole(UserRole userRole)
        {
            try
            {
                var res=_dbContext.UserRole.Where(p=>p.UserRoleId==userRole.UserRoleId).AsNoTracking().FirstOrDefault();
                if (res != null)
                {
                    userRole.UpdatedBy = "Admin";
                    userRole.UpdatedDate = DateTime.Now;
                    _dbContext.UserRole.Update(userRole);
                    _dbContext.SaveChanges();
                }
                
                return userRole;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public UserRole GetById(UserRole userRole)
        {
            var res = _dbContext.UserRole.Where(p => p.UserRoleId == userRole.UserRoleId).FirstOrDefault();
            return res;
        }


    }


    public interface IUserRoleBLLManager
    {
        UserRole AddUserRole(UserRole userRole);
        List<UserRole> GetAll();
        UserRole UpdateUserRole(UserRole userRole);
        UserRole GetById(UserRole userRole);
        List<UserRole> Search(string UserName);
    }
}
