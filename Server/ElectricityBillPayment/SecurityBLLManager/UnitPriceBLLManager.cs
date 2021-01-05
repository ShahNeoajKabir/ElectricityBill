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
    public class UnitPriceBLLManager: IUnitPriceBLLManager
    {

        private readonly DatabaseContext _database;
        public UnitPriceBLLManager(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<UnitPrice>AddUnitPrice(UnitPrice unitPrice)
        {
            try
            {
                if(unitPrice.UnitperPrice>0 && unitPrice.CustomerType > 0)
                {
                    unitPrice.CreatedDate = DateTime.Now;
                    await _database.UnitPrice.AddAsync(unitPrice);
                    await _database.SaveChangesAsync();
                    return unitPrice;
                }
                else
                {
                    throw new Exception("");
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<UnitPrice> GetAll()
        {
            List<UnitPrice> unitPrice = _database.UnitPrice.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
            return unitPrice;
        }

        public async Task<UnitPrice>UpdateUnitPrice(UnitPrice unitPrice)
        {
            try
            {
                var res = await _database.UnitPrice.Where(p => p.UnitPriceId == unitPrice.UnitPriceId).AsNoTracking().FirstOrDefaultAsync();
                if (res != null)
                {
                    
                    unitPrice.UpdatedDate = DateTime.Now;
                    _database.UnitPrice.Update(unitPrice);
                    await _database.SaveChangesAsync();
                }
                return unitPrice;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<UnitPrice>GetById(UnitPrice unitPrice)
        {
           var res= await _database.UnitPrice.Where(p => p.UnitPriceId == unitPrice.UnitPriceId).FirstOrDefaultAsync();
            return res;
        }
    }

    public interface IUnitPriceBLLManager
    {
        Task<UnitPrice> AddUnitPrice(UnitPrice unitPrice);
        List<UnitPrice> GetAll();
        Task<UnitPrice> UpdateUnitPrice(UnitPrice unitPrice);
        Task<UnitPrice> GetById(UnitPrice unitPrice);
    }

}
