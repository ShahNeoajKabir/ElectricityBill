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
    public class ZoneAssignBLLManager: IZoneAssignBLLManager
    {

        private readonly DatabaseContext _database;
        public ZoneAssignBLLManager(DatabaseContext database)
        {
            _database = database;
        }


        public async Task<ZoneAssign>AssignZone(ZoneAssign zoneAssign)
        {
            try
            {
                
                    zoneAssign.CreatedBy = "Admin";
                    zoneAssign.CreatedDate = DateTime.Now;
                    await _database.ZoneAssign.AddAsync(zoneAssign);
                    await _database.SaveChangesAsync();
                    
                

            }
            catch (Exception ex)
            {

                throw;
            }
            return zoneAssign;
        }


        public List<ZoneAssign> GetAll()
        {
            List<ZoneAssign> zoneAssign = _database.ZoneAssign.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(t => new ZoneAssign()
            {
                CreatedBy=t.CreatedBy,
                CreatedDate=t.CreatedDate,
                ZoneAssignId=t.ZoneAssignId,
                User=t.User,
                UserId=t.UserId,
                Zone=t.Zone,
                ZoneId=t.ZoneId,
                Status=t.Status
            }).ToList();
            return zoneAssign;
        }

        public async Task<ZoneAssign> UpdateZoneAssign(ZoneAssign zoneAssign)
        {
            try
            {
                var res = await _database.ZoneAssign.Where(p => p.ZoneAssignId == zoneAssign.ZoneAssignId).AsNoTracking().FirstOrDefaultAsync();
                if (res != null)
                {
                    zoneAssign.UpdatedBy = "Admin";
                    zoneAssign.UpdatedDate = DateTime.Now;
                    _database.ZoneAssign.Update(zoneAssign);
                    await _database.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Update Failed");
                }
                return zoneAssign;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<ZoneAssign>GetById(ZoneAssign zoneAssign)
        {
            var res = await _database.ZoneAssign.Where(p => p.ZoneAssignId == zoneAssign.ZoneAssignId).FirstOrDefaultAsync();
            return res;
        }

        public async Task<List<ZoneAssign>> Search(string UserName)
        {
            var search = await _database.ZoneAssign.Where(c => c.User.UserName.Contains(UserName)).ToListAsync();
            return search;
        }
    }

    public interface IZoneAssignBLLManager
    {
        List<ZoneAssign> GetAll();
        Task<ZoneAssign> AssignZone(ZoneAssign zoneAssign);
        Task<ZoneAssign> GetById(ZoneAssign zoneAssign);
        Task<ZoneAssign> UpdateZoneAssign(ZoneAssign zoneAssign);
        Task<List<ZoneAssign>> Search(string UserName);
    }
}
