using Context;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager
{
    public class PaymentGetwayBLLManager: IPaymentGetwayBLLManager
    {
        private readonly DatabaseContext _database;
        public PaymentGetwayBLLManager(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<CardInformation> GetCardInformation(CardInformation cardInformation)
        {
            var res = _database.CardInformation.Where(p => p.CardNumber == cardInformation.CardNumber && p.CVV == cardInformation.CVV && p.ExpiredDate == cardInformation.ExpiredDate).FirstOrDefault();
            if (res.Pin != cardInformation.Pin)
            {
                throw new Exception("Invalide Pin Number");
            }
            return res;
            
        }

        public async Task<MobileBanking> GetMobileBankingInformation(MobileBanking mobileBanking)
        {
            var res = _database.MobileBanking.Where(p => p.MobileNo == mobileBanking.MobileNo).FirstOrDefault();
            if (res.Pin != mobileBanking.Pin)
            {
                throw new Exception("Invalide Pin Number");
            }
            return res;
        }
    }


    public interface IPaymentGetwayBLLManager
    {
        Task<CardInformation> GetCardInformation(CardInformation cardInformation);
        Task<MobileBanking> GetMobileBankingInformation(MobileBanking mobileBanking);
    }
}
