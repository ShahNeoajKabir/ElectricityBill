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
    public class RolePermissionBLLManager: IRolePermissionBLLManager
    {
        private readonly DatabaseContext _database;
        public RolePermissionBLLManager(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<URL>AddUrl(URL uRL)
        {
            try
            {
                await _database.URL.AddAsync(uRL);
                await _database.SaveChangesAsync();
                return uRL;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<RolePermission> AddRolePermission(RolePermission rolePermission)
        {
            try
            {
                await _database.RolePermission.AddAsync(rolePermission);
                await _database.SaveChangesAsync();
                return rolePermission;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<RolePermission>GetById(RolePermission rolePermission)
        {
            try
            {
                var res = await _database.RolePermission.Where(p => p.RolePermissionId == rolePermission.RolePermissionId).FirstOrDefaultAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }


    public interface IRolePermissionBLLManager
    {
        Task<URL> AddUrl(URL uRL);
        Task<RolePermission> AddRolePermission(RolePermission rolePermission);
        Task<RolePermission> GetById(RolePermission rolePermission);
    }
}
