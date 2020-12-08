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
    public class ZoneBLLManager : IZoneBLLManager
    {

        private readonly DatabaseContext _dbContext;
        public ZoneBLLManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Zone> AddZone(Zone zone)
        {
            try
            {
                zone.CreatedBy = "Admin";
                zone.CreatedDate = DateTime.Now;
                await _dbContext.Zone.AddAsync(zone);
                await _dbContext.SaveChangesAsync();
                return zone;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<Zone> GetAll()
        {
            List<Zone> zone = _dbContext.Zone.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
            return zone;
        }


        public async Task<List<Zone>> Search(string ZoneName)
        {
            var search =await _dbContext.Zone.Where(c => c.ZoneName.Contains(ZoneName)).ToListAsync();
            return search;
        }


        public async Task<Zone> UpdateZone(Zone zone)
        {
            try
            {
                var id = await _dbContext.Zone.Where(c => c.ZoneId == zone.ZoneId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    zone.UpdatedBy = "Admin";
                    zone.UpdatedDate = DateTime.Now;
                    _dbContext.Zone.Update(zone);
                   await _dbContext.SaveChangesAsync();
                }





            }
            catch (Exception)
            {

                throw;
            }
            return zone;
        }

        public async Task<Zone> GetById(Zone zone)
        {
            var res = await _dbContext.Zone.Where(p => p.ZoneId == zone.ZoneId).FirstOrDefaultAsync();
            return res;
        }
    }

    public interface IZoneBLLManager
    {
        Task<Zone> AddZone(Zone zone);
        List<Zone> GetAll();
        Task<Zone> UpdateZone(Zone zone);
        Task<Zone> GetById(Zone zone);
        Task<List<Zone>> Search(string ZoneName);

    }
}
