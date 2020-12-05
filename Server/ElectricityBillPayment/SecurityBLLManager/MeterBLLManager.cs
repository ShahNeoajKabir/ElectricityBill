using Electricity.DAL;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class MeterBLLManager : IMeterBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public MeterBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MeterTable AddMeter(MeterTable meter)
        {
            try
            {
                meter.CreatedBy = "Admin";
                meter.CreatedDate = DateTime.Now;
                 _dbContext.MeterTable.Add(meter);
                 _dbContext.SaveChanges();
                return meter;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MeterTable> GetAll()
        {
            List<MeterTable> meter = new List<MeterTable>();
            var meterassignLiost = _dbContext.MeterAssign.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).Select(c => c.MeterId).ToArray();
            if (meterassignLiost.Length > 0)
            {
                meter = _dbContext.MeterTable.Where(p => !meterassignLiost.Contains(p.MeterId) && p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToList();

            }
            else
            {
                meter = _dbContext.MeterTable.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToList();

            }

            return meter;
        }


        public MeterTable UpdateMeter(MeterTable meter)
        {
            try
            {
                
                    meter.UpdatedBy = "Admin";
                    meter.UpdatedDate = DateTime.Now;
                    _dbContext.MeterTable.Update(meter);
                     _dbContext.SaveChanges();
                    return meter;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MeterTable GetById(MeterTable meter)
        {
            return _dbContext.MeterTable.Find(meter.MeterId);
        }
    }


    public interface IMeterBLLManager
    {
        MeterTable AddMeter(MeterTable meter);
        List<MeterTable> GetAll();
        MeterTable UpdateMeter(MeterTable meter);
        MeterTable GetById(MeterTable meter);


    }
}
