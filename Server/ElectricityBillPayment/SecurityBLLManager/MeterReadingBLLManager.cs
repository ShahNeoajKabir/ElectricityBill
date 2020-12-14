using Context;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using ModelClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager
{
    public class MeterReadingBLLManager: IMeterReadingBLLManager
    {
        private readonly DatabaseContext _database;
        public MeterReadingBLLManager(DatabaseContext database)
        {
            _database = database;
        }


        public async Task<MeterReadingTable> AddMeterReading(VMAddMeterReading VmMeter)
        {
            MeterReadingTable meterReadingTable = new MeterReadingTable();
            Customer customer = new Customer();
            MeterTable meter = new MeterTable();
            try
            {
                var mobileno = await _database.Customer.Where(p => p.MobileNo == VmMeter.MobileNo).FirstOrDefaultAsync();
                var meternumber = await _database.MeterTable.Where(p => p.MeterNumber == VmMeter.MeterNumber).FirstOrDefaultAsync();
                if(mobileno!=null && meternumber != null)
                {
                    meterReadingTable.CreatedBy = "MeterReader";
                    meterReadingTable.CreatedDate = DateTime.Now;
                    await _database.MeterReadingTable.AddAsync(meterReadingTable);
                    await _database.SaveChangesAsync();
                    
                }
                else
                {
                    throw new Exception("Mobile No Or Meter Number Not Matched");
                }

                return meterReadingTable;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<MeterReadingTable> GetAll()
        {
            List<MeterReadingTable> meter = _database.MeterReadingTable.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
            return meter;
        }

        public async Task<MeterReadingTable>UpdateMeterReading(MeterReadingTable meter)
        {
            try
            {
                var res = await _database.MeterReadingTable.Where(p => p.MeterReadingId == meter.MeterReadingId).AsNoTracking().FirstOrDefaultAsync();
                if (res != null)
                {
                    meter.UpdatedBy = "MeterReader";
                    meter.UpdatedDate = DateTime.Now;
                    _database.MeterReadingTable.Update(meter);
                    await _database.SaveChangesAsync();
                }

                return meter;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<MeterReadingTable> GetById(MeterReadingTable meter)
        {
            var res = await _database.MeterReadingTable.Where(p => p.MeterReadingId == meter.MeterReadingId).FirstOrDefaultAsync();
            return res;
        }

        //public async Task<List<MeterReadingTable>> Search(string UserName)
        //{
        //    var search = await _database.MeterReadingTable.Where(c => c.MeterAssignId.Contains(UserName)).ToListAsync();
        //    return search;
        //}


    }

    public interface IMeterReadingBLLManager
    {
        Task<MeterReadingTable> AddMeterReading(VMAddMeterReading VmMeter);
        List<MeterReadingTable> GetAll();
        Task<MeterReadingTable> UpdateMeterReading(MeterReadingTable meter);
        Task<MeterReadingTable> GetById(MeterReadingTable meter);
    }
}
