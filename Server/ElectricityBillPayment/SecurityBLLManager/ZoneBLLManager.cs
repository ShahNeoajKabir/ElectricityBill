using Electricity.DAL;
using Microsoft.EntityFrameworkCore;
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


        public List<Zone>Search(string ZoneName)
        {
            var search = _dbContext.Zone.Where(c => c.ZoneName.Contains(ZoneName)).ToList();
            return search;
        }


        public Zone UpdateZone(Zone zone)
        {
            try
            {
                var id = _dbContext.Zone.Where(c => c.ZoneId == zone.ZoneId).AsNoTracking().FirstOrDefault();
                if (id != null)
                {
                    zone.UpdatedBy = "Admin";
                    zone.UpdatedDate = DateTime.Now;
                    _dbContext.Zone.Update(zone);
                    _dbContext.SaveChanges();
                }
                
                    

                
                
            }
            catch (Exception)
            {

                throw;
            }
            return zone;
        }

        public Zone GetById(Zone zone)
        {
            var res= _dbContext.Zone.Where(p=>p.ZoneId==zone.ZoneId).FirstOrDefault();
            return res;
        }
    }

    public interface IZoneBLLManager
    {
        Zone AddZone(Zone zone);
       List<Zone> GetAll();
        Zone UpdateZone(Zone zone);
        Zone GetById(Zone zone);
        List<Zone> Search(string ZoneName);

    }
}
