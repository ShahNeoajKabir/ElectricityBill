using Common.Electricity.Utility;
using Context;
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
                objuser = _dbContext.User.Where(p => p.Email == vMLogin.UserName && p.Password == vMLogin.Password).Select(u => new User()
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
