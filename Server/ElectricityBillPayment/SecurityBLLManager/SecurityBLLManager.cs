using Electricity.Common.Utility;
using Electricity.DAL;
using ModelClass.DTO;
using ModelClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager
{
    public class SecurityBLLManager :ISecurityBLLmanager
    {
        private readonly PaymentDbContext _dbContext;
        public SecurityBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> Login(VMLogin vMLogin)
        {
            User objuser = new User();
            try
            {
                vMLogin.Password = new EncryptionService().Encrypt(vMLogin.Password);
                objuser = _dbContext.User.Where(p => p.Email == vMLogin.Email && p.Password == vMLogin.Password).Select(u => new User()
                {
                    UserTypeId = u.UserTypeId,
                    Email = u.Email
                }).FirstOrDefault();


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
