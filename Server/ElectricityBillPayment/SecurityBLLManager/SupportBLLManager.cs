using Electricity.DAL;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class SupportBLLManager : ISupportBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public SupportBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Support AddSupport(Support support)
        {
            try
            {
                support.CreatedBy = "Customer";
                support.CreatedDate = DateTime.Now;
                _dbContext.Support.Add(support);
                _dbContext.SaveChanges();
                return support;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Support> GetAll()
        {
            List<Support> support = _dbContext.Support.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToList();
            return support;
        }


        public List<Support> Search(string SupportSubject)
        {
            var search = _dbContext.Support.Where(c => c.SupportSubject.Contains(SupportSubject)).ToList();
            return search;
        }

        public Support UpdateSupport(Support support)
        {
            try
            {
                var id = _dbContext.Support.Where(p => p.SupportId == support.SupportId).AsNoTracking().FirstOrDefault();
                if (id != null)
                {
                    support.UpdatedBy = "Customer";
                    support.UpdatedDate = DateTime.Now;
                    _dbContext.Support.Update(support);
                    _dbContext.SaveChanges();
                }


                return support;



            }
            catch (Exception)
            {

                throw;
            }
        }

        public Support GetById(Support support)
        {
            var res= _dbContext.Support.Where(p=>p.SupportId==support.SupportId).FirstOrDefault();
            return res;
        }


    }


    public interface ISupportBLLManager
    {
        Support AddSupport(Support support);
        List<Support> GetAll();
        Support UpdateSupport(Support support);
        Support GetById(Support support);
        List<Support> Search(string SupportSubject);
    }
}
