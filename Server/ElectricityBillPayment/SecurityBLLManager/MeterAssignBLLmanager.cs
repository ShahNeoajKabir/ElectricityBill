using Electricity.DAL;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class MeterAssignBLLmanager: IMeterAssignBLLmanager
    {

        private readonly PaymentDbContext _dbContext;
        public MeterAssignBLLmanager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public MeterAssign AssignMeter(MeterAssign meter)
        {
            try
            {
                meter.CreatedBy = "CoOrdinator";
                meter.CreatedDate = DateTime.Now;
                _dbContext.MeterAssign.Add(meter);
                _dbContext.SaveChanges();
                return meter;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MeterAssign> GetAll()
        {
            List<MeterAssign> meter = _dbContext.MeterAssign.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToList();
            return meter;

        }

        public MeterAssign UpdateAssign(MeterAssign meter)
        {
            try
            {
                var res = _dbContext.MeterAssign.Where(p => p.MeterAssignId == meter.MeterAssignId).FirstOrDefault();
                if (res != null)
                {
                    meter.UpdatedBy = "CoOrdinator";
                    meter.UpdatedDate = DateTime.Now;
                    _dbContext.MeterAssign.Update(meter);
                    _dbContext.SaveChanges();
                    
                }
                else
                {
                    throw new Exception("Inavlide Request");
                }
                return meter;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MeterAssign GetById(MeterAssign meter)
        {
            return _dbContext.MeterAssign.Find(meter.MeterId);
        }
    }

    public interface IMeterAssignBLLmanager
    {
        MeterAssign AssignMeter(MeterAssign meter);
        List<MeterAssign> GetAll();
        MeterAssign UpdateAssign(MeterAssign meter);
        MeterAssign GetById(MeterAssign meter);
    }
}
