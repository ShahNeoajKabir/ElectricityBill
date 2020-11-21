
using Contextt;
using ElectricBillPayment.Common.Utility;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ElectricityBillPayment.Bll
{
    public class RoleBLLManager: IRoleBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public RoleBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }   

        public async Task<Role> AddRole(Role role)
        {
            try
            {
                role.CreatedBy = "Admin";
                role.CreatedDate = DateTime.Now;
                role.Status = (int)ElectricBillPayment.Common.Enum.Enum.Status.Active;
                await _dbContext.Role.AddAsync(role);
                await _dbContext.SaveChangesAsync();
                return role;
            }
            catch (Exception)
            {

                throw new Exception("Can Not Added");
            }
        } 

        public async Task<List<Role>> GetAll()
        {
            List<Role> role = await _dbContext.Role.Where(p => p.Status == (int)ElectricBillPayment.Common.Enum.Enum.Status.Active).ToListAsync();
            return role;

        }

        public async Task<Role>UpdateRole(Role role)
        {
            try
            {
                var res = await _dbContext.Role.Where(e => e.RoleId == role.RoleId).FirstOrDefaultAsync();
                if (res != null)
                {
                    role.UpdatedBy = "Admin";
                    role.UpdatedDate = DateTime.Now;
                    _dbContext.Role.Update(role);
                    await _dbContext.SaveChangesAsync();
                   
                }
                else
                {
                    throw new Exception("Failed To Update");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return role;
        }

        public Role GetById(Role role)
        {
            return _dbContext.Role.Find(role.RoleId);
        }

    }

    public interface IRoleBLLManager
    {
        Task<Role> AddRole(Role role);
        Task<List<Role>> GetAll();
        Task<Role> UpdateRole(Role role);
        Role GetById(Role role);
    }
}
