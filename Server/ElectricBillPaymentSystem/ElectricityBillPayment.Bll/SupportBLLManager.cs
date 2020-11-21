
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
    public class SupportBLLManager: ISupportBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public SupportBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Support>AddSupport(Support support)
        {
            try
            {
                support.CreatedBy = "Customer";
                support.CreatedDate = DateTime.Now;
                support.Status = (int)ElectricBillPayment.Common.Enum.Enum.Status.Active;
                await _dbContext.Support.AddAsync(support);
                await _dbContext.SaveChangesAsync();
                return support;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Support>> GetAll()
        {
            List<Support> support = await _dbContext.Support.Where(p => p.Status == (int)ElectricBillPayment.Common.Enum.Enum.Status.Active).ToListAsync();
            return support;
        }

        public async Task<Support>UpdateSupport(Support support)
        {
            try
            {
                var res = await _dbContext.Support.Where(p => p.SupportId == support.SupportId).FirstOrDefaultAsync();
                if (res!=null)
                {
                    support.UpdatedBy = "Customer";
                    support.UpdatedDate = DateTime.Now;
                    _dbContext.Support.Update(support);
                    await _dbContext.SaveChangesAsync();
                    return support;
                }

                else
                {
                    throw new Exception("Update Failed");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Support GetById(Support support)
        {
            return _dbContext.Support.Find(support.SupportId);
        }


    }


    public interface ISupportBLLManager
    {
        Task<Support> AddSupport(Support support);
        Task<List<Support>> GetAll();
        Task<Support> UpdateSupport(Support support);
        Support GetById(Support support);
    }
}
