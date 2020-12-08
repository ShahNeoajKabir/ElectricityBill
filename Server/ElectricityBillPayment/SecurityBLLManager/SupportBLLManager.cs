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
    public class SupportBLLManager : ISupportBLLManager
    {
        private readonly DatabaseContext _dbContext;
        public SupportBLLManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Support> AddSupport(Support support)
        {
            try
            {
                support.CreatedBy = "Customer";
                support.CreatedDate = DateTime.Now;
                await _dbContext.Support.AddAsync(support);
                await _dbContext.SaveChangesAsync();
                return support;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Support> GetAll()
        {
            List<Support> support = _dbContext.Support.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
            return support;
        }


        public async Task<List<Support>> Search(string SupportSubject)
        {
            var search = await _dbContext.Support.Where(c => c.SupportSubject.Contains(SupportSubject)).ToListAsync();
            return search;
        }

        public async Task<Support> UpdateSupport(Support support)
        {
            try
            {
                var id = await _dbContext.Support.Where(p => p.SupportId == support.SupportId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    support.UpdatedBy = "Customer";
                    support.UpdatedDate = DateTime.Now;
                    _dbContext.Support.Update(support);
                    await _dbContext.SaveChangesAsync();
                }


                return support;



            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Support> GetById(Support support)
        {
            var res = await _dbContext.Support.Where(p => p.SupportId == support.SupportId).FirstOrDefaultAsync();
            return res;
        }


    }


    public interface ISupportBLLManager
    {
        Task<Support> AddSupport(Support support);
        List<Support> GetAll();
        Task<Support> UpdateSupport(Support support);
        Task<Support> GetById(Support support);
        Task<List<Support>> Search(string SupportSubject);
    }
}
