using Context;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricBillPayment.BLL
{
   public class NoticeBLLManager: INoticeBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public NoticeBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Notice AddNotice(Notice notice)
        {
            try
            {
                notice.CreatedBy = "CoOrdinator";
                notice.CreatedDate = DateTime.Now;
                _dbContext.Notice.Add(notice);
                _dbContext.SaveChanges();
                return notice;
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
        }

        public List<Notice> GetAll()
        {
            List<Notice> notice = _dbContext.Notice.Where(p => p.Status == (int)ElectricBillPayment.Common.Enum.Enum.Status.Active).ToList();
            return notice;
        }

        public Notice GetById(Notice notice)
        {
            return _dbContext.Notice.Find(notice.NoticeId);
             
        }

        public Notice UpdateNotice(Notice notice)
        {
            try
            {
                var res = _dbContext.Notice.Where(e => e.NoticeId == notice.NoticeId).FirstOrDefault();
                if (res != null)
                {
                    notice.UpdatedBy = "CoOrdinator";
                    notice.UpdatedDate = DateTime.Now;
                    _dbContext.Notice.Update(notice);
                    _dbContext.SaveChanges();
                }

                else
                {
                    throw new Exception("Notice Not Found");
                }
                
                return notice;
            }
            catch (Exception ex)
            {
               
                throw;
            }
        }
    }


    public interface INoticeBLLManager
    {
        Notice AddNotice(Notice notice);
        List<Notice> GetAll();
        Notice UpdateNotice(Notice notice);
    }
}
