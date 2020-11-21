
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
    public class NoticeBLLManager: INoticeBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public NoticeBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Notice>AddNotice(Notice notice)
        {
            try
            {
                notice.CreatedBy = "CoOrdinator";
                notice.CreatedDate = DateTime.Now;
                notice.Status = (int)ElectricBillPayment.Common.Enum.Enum.Status.Active;
                await _dbContext.Notice.AddAsync(notice);
                await _dbContext.SaveChangesAsync();
                return notice;

            }
            catch (Exception)
            {

                throw new Exception("Failed To Create");
            }
        }


        public async Task<List<Notice>> GetAll()
        {
            List<Notice> notice =await _dbContext.Notice.Where(p => p.Status == (int)ElectricBillPayment.Common.Enum.Enum.Status.Active).ToListAsync();
            return notice;
        }

        public async Task<Notice>UpdateNotice(Notice notice)
        {
            try
            {
                var res = await _dbContext.Notice.Where(p => p.NoticeId == notice.NoticeId).FirstOrDefaultAsync();
                if (res != null)
                {
                    notice.UpdatedBy = "CoOrdinator";
                    notice.UpdatedDate = DateTime.Now;
                    _dbContext.Notice.Update(notice);
                    await _dbContext.SaveChangesAsync();
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
        Task<Notice> AddNotice(Notice notice);
        Task<List<Notice>> GetAll();
        Task<Notice> UpdateNotice(Notice notice);
        Notice GetById(Notice notice);
    }
}
