using Context;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricBillPayment.BLL
{
    public class RoleBllManager: IRoleBllManager
    {
        private readonly PaymentDbContext _dbContext;
        public RoleBllManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Role AddRole(Role role)
        {
            try
            {
                role.CreatedBy = "Admin";
                role.CreatedDate = DateTime.Now;
                role.Status = (int)ElectricBillPayment.Common.Enum.Enum.Status.Active;
                _dbContext.Role.Add(role);
                _dbContext.SaveChanges();
                return role;
            }
            catch (Exception)
            {

                throw new Exception("Invalide Request");
            }
            
        }


        public List<Role> GetAll()
        {
            List<Role> role = _dbContext.Role.Where(p => p.Status == (int)ElectricBillPayment.Common.Enum.Enum.Status.Active).ToList();
            return role;
        }

        public Role UpdateRole(Role role)
        {
            try
            {
                var res = _dbContext.Role.Where(e => e.RoleId == role.RoleId).FirstOrDefault();
                if (res != null)
                {
                    role.UpdatedBy = "Admin";
                    role.UpdatedDate = DateTime.Now;
                    _dbContext.Role.Update(role);
                    _dbContext.SaveChanges();
                }

                else
                {
                    throw new Exception("Failed To Update");
                }
                return role;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Role GetById(Role role)
        {
            return _dbContext.Role.Find(role.RoleId);
        }

    }

    public interface IRoleBllManager
    {
        Role AddRole(Role role);
        List<Role> GetAll();
        Role UpdateRole(Role role);
        Role GetById(Role role);
    }
}
