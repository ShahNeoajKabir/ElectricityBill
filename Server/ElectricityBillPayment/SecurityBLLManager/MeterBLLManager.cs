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
    public class MeterBLLManager : IMeterBLLManager
    {
        private readonly DatabaseContext _dbContext;
        public MeterBLLManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MeterTable> AddMeter(MeterTable meter)
        {
            try
            {
                if(meter.MeterNumber!=null && meter.ExpiredDate!=null && meter.Status > 0)
                {
                    var meternumbercheck = _dbContext.MeterTable.Where(p => p.MeterNumber == meter.MeterNumber).FirstOrDefault();
                    if (meternumbercheck != null)
                    {
                        throw new Exception("");
                    }
                    else
                    {
                        meter.CreatedDate = DateTime.Now;

                        await _dbContext.MeterTable.AddAsync(meter);
                        await _dbContext.SaveChangesAsync();
                    }
                   
                    return meter;
                }
                else
                {
                    throw new Exception("Failed To Add");
                    return meter;
                }

                

            }
            catch (Exception ex)
            {

                throw new Exception("Failed To Added");
            }
        }

        public List<MeterTable> GetAll()
        {
            List<MeterTable> meter = new List<MeterTable>();
            var meterassignLiost = _dbContext.MeterAssign.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(c => c.MeterId).ToArray();
            if (meterassignLiost.Length > 0)
            {
                meter = _dbContext.MeterTable.Where(p => !meterassignLiost.Contains(p.MeterId) && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();

            }
            else
            {
                meter =  _dbContext.MeterTable.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();

            }

            return meter;
        }

        public List<MeterTable> GetAllMeter()
        {
            List<MeterTable> meter = _dbContext.MeterTable.ToList();
            return meter;
        }
        public async Task<List<MeterTable>> Search(string MeterNumber)
        {
            var search = await _dbContext.MeterTable.Where(c => c.MeterNumber.Contains(MeterNumber)).ToListAsync();
            return search;
        }


        public async Task<MeterTable> UpdateMeter(MeterTable meter)
        {
            try
            {
                var id = await _dbContext.MeterTable.Where(p => p.MeterId == meter.MeterId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    
                    meter.UpdatedDate = DateTime.Now;
                    _dbContext.MeterTable.Update(meter);
                    await _dbContext.SaveChangesAsync();
                    return meter;
                }
                else
                {
                    throw new Exception("Failed To Update");
                    return meter;
                }

                

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<MeterTable> GetById(MeterTable meter)
        {
            var res = await _dbContext.MeterTable.Where(c => c.MeterId == meter.MeterId).FirstOrDefaultAsync();
            return res;
        }
    }


    public interface IMeterBLLManager
    {
        Task<MeterTable> AddMeter(MeterTable meter);
        List<MeterTable> GetAll();
        Task<MeterTable> UpdateMeter(MeterTable meter);
        Task<MeterTable> GetById(MeterTable meter);
        Task<List<MeterTable>> Search(string MeterNumber);
        List<MeterTable> GetAllMeter();

    }
}
