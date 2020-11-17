using Context;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricBillPayment.BLL
{
    public class SupportBllManager: ISupportBllManager
    {
        private readonly PaymentDbContext _dbContext;
        public SupportBllManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Support AddSupport(Support support)
        {
            try
            {
                support.CreatedBy = "Admin";
                support.CreatedDate = DateTime.Now;
                support.Status = (int)ElectricBillPayment.Common.Enum.Enum.Status.Active;
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
            List<Support> support = _dbContext.Support.Where(p => p.Status == (int)ElectricBillPayment.Common.Enum.Enum.Status.Active).ToList();
            return support;
        }

        public Support UpdateSupport(Support support)
        {
            try
            {
                var res = _dbContext.Support.Where(e => e.SupportId == support.SupportId).FirstOrDefault();
                if (res != null)
                {
                    support.UpdatedBy = "Admin";
                    support.UpdatedDate = DateTime.Now;
                    _dbContext.Support.Update(support);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Updated Failed");
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
            return _dbContext.Support.Find(support.SupportId);
        }
    }


    public interface ISupportBllManager
    {
        Support AddSupport(Support support);
        List<Support> GetAll();
        Support UpdateSupport(Support support);
        Support GetById(Support support);
    }
}
