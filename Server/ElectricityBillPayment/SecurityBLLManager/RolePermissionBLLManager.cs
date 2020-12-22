using Context;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using ModelClass.ViewModel;
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
                var url = _database.URL.Where(p => p.Url == uRL.Url).FirstOrDefault();
                if (url != null)
                {
                    throw new Exception("Url Already exists");
                }
                await _database.URL.AddAsync(uRL);
                await _database.SaveChangesAsync();
                return uRL;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<URL> GetAll()
        {
            List<URL>uRLs= _database.URL.ToList();
            return uRLs;
        }
        public async Task<VMRolePermission> AddRolePermission(VMRolePermission vMRolePermission)
        {
            try
            {
                var rolepermission = _database.RolePermission.AsNoTracking().Where(p => p.RoleId == vMRolePermission.RoleId).ToList();
                if (rolepermission.Count > 0)
                {
                    _database.RolePermission.RemoveRange(rolepermission);
                    await _database.SaveChangesAsync();

                }
                foreach (var item in vMRolePermission.Urls)
                {
                    var rolepermissions = new RolePermission()
                    {
                        RoleId = vMRolePermission.RoleId,
                        UrlId = item.UrlId,


                    };
                    _database.RolePermission.Add(rolepermissions);
                    

                }
                _database.SaveChanges();
                return vMRolePermission;
                

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
        Task<VMRolePermission> AddRolePermission(VMRolePermission vMRolePermission);
        Task<RolePermission> GetById(RolePermission rolePermission);
        List<URL> GetAll();
    }
}
