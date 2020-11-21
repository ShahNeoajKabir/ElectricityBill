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
                meter.Status = (int)Electricity.Common.Enum.Enum.Status.Active;
                 _dbContext.MeterTable.AddAsync(meter);
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
            List<MeterTable> meter = _dbContext.MeterTable.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToList();
            return meter;
        }


        public MeterTable UpdateMeter(MeterTable meter)
        {
            try
            {
                var res =  _dbContext.MeterTable.Where(e => e.MeterId == meter.MeterId).FirstOrDefault();
                if (res != null)
                {
                    meter.UpdatedBy = "Admin";
                    meter.UpdatedDate = DateTime.Now;
                    _dbContext.MeterTable.Update(meter);
                     _dbContext.SaveChanges();
                    return meter;
                }

                else
                {
                    throw new Exception("Failed To Update");
                }
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
