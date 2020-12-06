using Electricity.DAL;
using Microsoft.EntityFrameworkCore;
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

        public List<Role>Search(string RoleName)
        {
            var search = _db.Role.Where(c => c.RoleName.Contains(RoleName)).ToList();
            return search;
        }

        public Role UpdateRole(Role role)
        {
            try
            {
                var id = _db.Role.Where(p => p.RoleId == role.RoleId).AsNoTracking().FirstOrDefault();
                if (id != null)
                {
                    role.UpdatedBy = "Admin";
                    role.UpdatedDate = DateTime.Now;
                    _db.Role.Update(role);
                    _db.SaveChanges();
                }
                    

                
            }
            catch (Exception)
            {

                throw;
            }
            return role;
        }
        public Role GetByID(Role role)
        {
            var res= _db.Role.Where(c=>c.RoleId==role.RoleId).FirstOrDefault();
            return res;
        }

    }

    public interface IRoleBLLManager
    {
        Role AddRole(Role role);
        List<Role> GetAll();
        Role UpdateRole(Role role);
        Role GetByID(Role role);
        List<Role> Search(string RoleName);
    }
}
