
using Contextt;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillPayment.Bll
{
    public class ZoneBLLManager: IZoneBLLManager
    {

        private readonly PaymentDbContext _dbContext;
        public ZoneBLLManager(PaymentDbContext dbContext)
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
                    throw new Exception("Failed");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return zone;
        }
    }

    public interface IZoneBLLManager
    {
        Task<Zone> AddZone(Zone zone);
        Task<List<Zone>> GetAll();
    }
}
