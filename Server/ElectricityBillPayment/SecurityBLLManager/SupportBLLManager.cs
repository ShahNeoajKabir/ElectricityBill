using Electricity.DAL;
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
            List<Support> support =  _dbContext.Support.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToList();
            return support;
        }

        public Support UpdateSupport(Support support)
        {
            try
            {
                
                    support.UpdatedBy = "Customer";
                    support.UpdatedDate = DateTime.Now;
                    _dbContext.Support.Update(support);
                    _dbContext.SaveChanges();
                    return support;
                

              
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
        Support AddSupport(Support support);
        List<Support> GetAll();
        Support UpdateSupport(Support support);
        Support GetById(Support support);
    }
}
