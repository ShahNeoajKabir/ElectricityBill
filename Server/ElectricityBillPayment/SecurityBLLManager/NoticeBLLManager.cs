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
    public class NoticeBLLManager : INoticeBLLManager
    {
        private readonly DatabaseContext _dbContext;
        public NoticeBLLManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Notice> AddNotice(Notice notice)
        {
            try
            {
                notice.CreatedBy = "CoOrdinator";
                notice.CreatedDate = DateTime.Now;
                await _dbContext.Notice.AddAsync(notice);
                await _dbContext.SaveChangesAsync();
                return notice;

            }
            catch (Exception)
            {

                throw new Exception("Failed To Create");
            }
        }


        public List<Notice> GetAll()
        {
            List<Notice> notice = _dbContext.Notice.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
            return notice;
        }

        public async Task<List<Notice>> Search(string NoticeName)
        {
            var search = await _dbContext.Notice.Where(c => c.Notices.Contains(NoticeName)).ToListAsync();
            return search;
        }

        public async Task<Notice> UpdateNotice(Notice notice)
        {
            try
            {
                var id = await _dbContext.Notice.Where(p => p.NoticeId == notice.NoticeId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    notice.UpdatedBy = "CoOrdinator";
                    notice.UpdatedDate = DateTime.Now;
                    _dbContext.Notice.Update(notice);
                   await _dbContext.SaveChangesAsync();
                }


                return notice;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Notice> GetById(Notice notice)
        {
            var res = await _dbContext.Notice.Where(c => c.NoticeId == notice.NoticeId).FirstOrDefaultAsync();
            return res;
        }


    }


    public interface INoticeBLLManager
    {
        Task<Notice> AddNotice(Notice notice);
        List<Notice> GetAll();
        Task<Notice> UpdateNotice(Notice notice);
        Task<Notice> GetById(Notice notice);
        Task<List<Notice>> Search(string NoticeName);
    }
}
