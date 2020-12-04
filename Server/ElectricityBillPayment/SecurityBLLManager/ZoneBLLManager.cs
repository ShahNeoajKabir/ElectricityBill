using Electricity.DAL;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class ZoneBLLManager : IZoneBLLManager
    {

        private readonly PaymentDbContext _dbContext;
        public ZoneBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Zone AddZone(Zone zone)
        {
            try
            {
                zone.CreatedBy = "Admin";
                zone.CreatedDate = DateTime.Now;
                _dbContext.Zone.Add(zone);
                 _dbContext.SaveChanges();
                return zone;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<Zone> GetAll()
        {
            List<Zone> zone =  _dbContext.Zone.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToList();
            return zone;
        }


        public Zone UpdateZone(Zone zone)
        {
            try
            {
                
                    zone.UpdatedBy = "Admin";
                    zone.UpdatedDate = DateTime.Now;
                    _dbContext.Zone.Update(zone);
                    _dbContext.SaveChanges();

                
                
            }
            catch (Exception)
            {

                throw;
            }
            return zone;
        }

        public Zone GetById(Zone zone)
        {
            return _dbContext.Zone.Find(zone.ZoneId);
        }
    }

    public interface IZoneBLLManager
    {
        Zone AddZone(Zone zone);
       List<Zone> GetAll();
        Zone UpdateZone(Zone zone);
        Zone GetById(Zone zone);

    }
}
