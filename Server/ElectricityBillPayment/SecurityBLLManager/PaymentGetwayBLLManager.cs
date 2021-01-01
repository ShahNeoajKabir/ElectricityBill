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
    public class PaymentGetwayBLLManager: IPaymentGetwayBLLManager
    {
        private readonly DatabaseContext _database;
        public PaymentGetwayBLLManager(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<CardInformation> GetCardInformation(CardInformation cardInformation)
        {
            var decpin = new EncryptionService().Encrypt(cardInformation.Pin);
            var res = _database.CardInformation.Where(p => p.CardNumber == cardInformation.CardNumber && p.CVV == cardInformation.CVV ).AsNoTracking().FirstOrDefault();
            if (res.Pin != decpin)
            {
                throw new Exception("Invalide Pin Number");
            }
            return res;
            
        }

        public async Task<MobileBanking> GetMobileBankingInformation(MobileBanking mobileBanking)
        {
            var decpin = new EncryptionService().Encrypt(mobileBanking.Pin);
            var res = _database.MobileBanking.Where(p => p.MobileNo == mobileBanking.MobileNo).AsNoTracking().FirstOrDefault();
            if (res.Pin != decpin)
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
