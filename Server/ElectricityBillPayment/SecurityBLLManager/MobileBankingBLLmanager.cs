using Common.Electricity.Utility;
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
    public class MobileBankingBLLmanager: IMobileBankingBLLmanager
    {
        private readonly DatabaseContext _database;
        public MobileBankingBLLmanager(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<MobileBanking>AddMobile(MobileBanking mobile)
        {
            try
            {
                if(mobile.MobileNo!=null && mobile.Pin!=null && mobile.Balance > 0)
                {
                    var check = _database.MobileBanking.Where(p => p.MobileNo == mobile.MobileNo).FirstOrDefault();
                    if (check != null)
                    {
                        throw new Exception("");
                    }
                    else
                    {
                        mobile.Status = (int)Common.Electricity.Enum.Enum.Status.Active;
                        mobile.Pin = new EncryptionService().Encrypt(mobile.Pin);
                        await _database.MobileBanking.AddAsync(mobile);
                        await _database.SaveChangesAsync();
                       
                    }
                }
                return mobile;
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }


        public List<MobileBanking> GetAll()
        {
            List<MobileBanking> mobile = _database.MobileBanking.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
            return mobile;
        }

        public async Task<MobileBanking>GetById(MobileBanking mobile)
        {
            try
            {
                var res = await _database.MobileBanking.Where(p => p.MobileBankingId == mobile.MobileBankingId).FirstOrDefaultAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }


    public interface IMobileBankingBLLmanager
    {
        Task<MobileBanking> AddMobile(MobileBanking mobile);
        List<MobileBanking> GetAll();
        Task<MobileBanking> GetById(MobileBanking mobile);
    }
}
