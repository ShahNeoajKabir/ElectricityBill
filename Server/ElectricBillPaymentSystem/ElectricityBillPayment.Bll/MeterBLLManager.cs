
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
    public class MeterBLLManager: IMeterBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public MeterBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MeterTable>AddMeter(MeterTable meter)
        {
            try
            {
                meter.CreatedBy = "Admin";
                meter.CreatedDate = DateTime.Now;
                meter.Status = (int)ElectricBillPayment.Common.Enum.Enum.Status.Active;
                await _dbContext.MeterTable.AddAsync(meter);
                await _dbContext.SaveChangesAsync();
                return meter;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<MeterTable>> GetAll()
        {
            List<MeterTable> meter = await _dbContext.MeterTable.Where(p => p.Status == (int)ElectricBillPayment.Common.Enum.Enum.Status.Active).ToListAsync();
            return meter;
        }


        public async Task<MeterTable>UpdateMeter(MeterTable meter)
        {
            try
            {
                var res = await _dbContext.MeterTable.Where(e => e.MeterId == meter.MeterId).FirstOrDefaultAsync();
                if (res != null)
                {
                    meter.UpdatedBy = "Admin";
                    meter.UpdatedDate = DateTime.Now;
                    _dbContext.MeterTable.Update(meter);
                    await _dbContext.SaveChangesAsync();
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
        Task<MeterTable> AddMeter(MeterTable meter);
        Task<List<MeterTable>> GetAll();
        Task<MeterTable> UpdateMeter(MeterTable meter);
        MeterTable GetById(MeterTable meter);


    }
}
