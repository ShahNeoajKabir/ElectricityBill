using Context;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricBillPayment.BLL
{
    public class ZoneBllManager: IZoneBllManager
    {
        private readonly PaymentDbContext _dbContext;
        public ZoneBllManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Zone>AddZone(Zone zone)
        {
            try
            {
                zone.CreatedBy = "Admin";
                zone.CreatedDate = DateTime.Now;
                zone.Status = (int)ElectricBillPayment.Common.Enum.Enum.Status.Active;
                await _dbContext.Zone.AddAsync(zone);
                await _dbContext.SaveChangesAsync();
                return zone;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Zone>> GetAll()
        {
            List<Zone> zone = await _dbContext.Zone.Where(p => p.Status == (int)ElectricBillPayment.Common.Enum.Enum.Status.Active).ToListAsync();
            return zone;
        }

        public async Task<Zone>UpdateZone(Zone zone)
        {
            try
            {
                var res = await _dbContext.Zone.Where(p => p.ZoneId == zone.ZoneId).FirstOrDefaultAsync();
                if (res != null)
                {
                    zone.UpdatedBy = "Admin";
                    zone.UpdatedDate = DateTime.Now;
                    _dbContext.Zone.Update(zone);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Failed To Update");
                }
                return zone;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Zone GetById(Zone zone)
        {
            return  _dbContext.Zone.Find(zone.ZoneId);
        }
    }

    public interface IZoneBllManager
    {
        Task<Zone> AddZone(Zone zone);
        Task<List<Zone>> GetAll();
        Task<Zone> UpdateZone(Zone zone);
        Zone GetById(Zone zone);
    }
}
