using Context;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager
{
    public class RoleBLLManager : IRoleBLLManager
    {
        private readonly DatabaseContext _db;
        public RoleBLLManager(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<Role> AddRole(Role role)
        {
            if (role.RoleName != null)
            {
                var check = _db.Role.Where(p => p.RoleName == role.RoleName).FirstOrDefault();
                if (check != null)
                {
                    throw new Exception("");
                }
                else
                {
                    role.CreatedDate = DateTime.Now;

                    await _db.Role.AddAsync(role);
                    await _db.SaveChangesAsync();
                    return role;
                }
                
            }
            else
            {
                throw new Exception("");
            }
            
        }

        public List<Role> GetAll()
        {
            List<Role> role = _db.Role.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
            return role;
        }

        public async Task<List<Role>> Search(string RoleName)
        {
            var search = await _db.Role.Where(c => c.RoleName.Contains(RoleName)).ToListAsync();
            return search;
        }

        public async Task<Role> UpdateRole(Role role)
        {
            try
            {
                var id = await _db.Role.Where(p => p.RoleId == role.RoleId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    
                    role.UpdatedDate = DateTime.Now;
                    _db.Role.Update(role);
                    await _db.SaveChangesAsync();
                }



            }
            catch (Exception)
            {

                throw;
            }
            return role;
        }
        public async Task<Role> GetByID(Role role)
        {
            var res =await _db.Role.Where(c => c.RoleId == role.RoleId).FirstOrDefaultAsync();
            return res;
        }

    }

    public interface IRoleBLLManager
    {
        Task<Role> AddRole(Role role);
        List<Role> GetAll();
        Task<Role> UpdateRole(Role role);
        Task<Role> GetByID(Role role);
        Task<List<Role>> Search(string RoleName);
    }
}
