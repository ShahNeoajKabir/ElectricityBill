using Electricity.DAL;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class NoticeBLLManager : INoticeBLLManager
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
            catch (Exception)
            {

                throw new Exception("Failed To Create");
            }
        }


        public List<Notice> GetAll()
        {
            List<Notice> notice =  _dbContext.Notice.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToList();
            return notice;
        }

        public Notice UpdateNotice(Notice notice)
        {
            try
            {
                var res =  _dbContext.Notice.Where(p => p.NoticeId == notice.NoticeId).FirstOrDefault();
                if (res != null)
                {
                    notice.UpdatedBy = "CoOrdinator";
                    notice.UpdatedDate = DateTime.Now;
                    _dbContext.Notice.Update(notice);
                     _dbContext.SaveChanges();
                    return notice;
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

        public Notice GetById(Notice notice)
        {
            return _dbContext.Notice.Find(notice.NoticeId);
        }

        
    }


    public interface INoticeBLLManager
    {
        Notice AddNotice(Notice notice);
        List<Notice> GetAll();
        Notice UpdateNotice(Notice notice);
        Notice GetById(Notice notice);
    }
}
