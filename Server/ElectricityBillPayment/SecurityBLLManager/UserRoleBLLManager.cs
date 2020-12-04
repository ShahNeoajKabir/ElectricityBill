using Electricity.DAL;
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
            List<UserRole> userRole = _dbContext.UserRole.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToList();
            return userRole;
        }


        public UserRole UpdateUserRole(UserRole userRole)
        {
            try
            {
                userRole.UpdatedBy = "Admin";
                userRole.UpdatedDate = DateTime.Now;
                _dbContext.UserRole.Update(userRole);
                _dbContext.SaveChanges();
                return userRole;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public UserRole GetById(UserRole userRole)
        {
            return _dbContext.UserRole.Find(userRole.UserRoleId);
        }


    }


    public interface IUserRoleBLLManager
    {
        UserRole AddUserRole(UserRole userRole);
        List<UserRole> GetAll();
        UserRole UpdateUserRole(UserRole userRole);
        UserRole GetById(UserRole userRole);
    }
}
