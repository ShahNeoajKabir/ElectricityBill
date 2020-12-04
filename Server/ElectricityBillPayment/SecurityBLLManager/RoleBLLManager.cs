using Electricity.DAL;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class RoleBLLManager : IRoleBLLManager
    {
        private readonly PaymentDbContext _db;
        public RoleBLLManager(PaymentDbContext db)
        {
            _db = db;
        }

        public Role AddRole(Role role)
        {
            role.CreatedBy = "Admin";
            role.CreatedDate = DateTime.Now;

            _db.Role.Add(role);
            _db.SaveChanges();
            return role;
        }

        public List<Role> GetAll()
        {
            List<Role> role = _db.Role.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToList();
            return role;
        }

        public Role UpdateRole(Role role)
        {
            try
            {
                
                    role.UpdatedBy = "Admin";
                    role.UpdatedDate = DateTime.Now;
                    _db.Role.Update(role);
                    _db.SaveChanges();

                
            }
            catch (Exception)
            {

                throw;
            }
            return role;
        }
        public Role GetByID(Role role)
        {
            return _db.Role.Find(role.RoleId);
        }

    }

    public interface IRoleBLLManager
    {
        Role AddRole(Role role);
        List<Role> GetAll();
        Role UpdateRole(Role role);
        Role GetByID(Role role);
    }
}
