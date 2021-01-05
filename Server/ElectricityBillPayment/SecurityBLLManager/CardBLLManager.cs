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
    public class CardBLLManager: ICardBLLManager
    {

        private readonly DatabaseContext _database;
        public CardBLLManager(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<CardInformation>AddCard(CardInformation card)
        {
            try
            {
                if(card.CardNumber!=null && card.CardName!=null && card.Balance>0 && card.CVV!=null)
                {
                    var cardcheck = _database.CardInformation.Where(p => p.CardNumber == card.CardNumber).FirstOrDefault();
                    if (cardcheck != null)
                    {
                        throw new Exception("");
                    }
                    else
                    {
                        card.Status = (int)Common.Electricity.Enum.Enum.Status.Active;
                        card.Pin = new EncryptionService().Encrypt(card.Pin);
                        await _database.CardInformation.AddAsync(card);
                        await _database.SaveChangesAsync();
                    }
                }
                
                return card;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<CardInformation> GetAll()
        {
            List<CardInformation> card = _database.CardInformation.ToList();
            return card;
        }


        public async Task<CardInformation>GetById(CardInformation card)
        {
            try
            {
                var res = await _database.CardInformation.Where(p => p.CardInformationId == card.CardInformationId).FirstOrDefaultAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }


    public interface ICardBLLManager
    {
        Task<CardInformation> AddCard(CardInformation card);
        List<CardInformation> GetAll();
        Task<CardInformation> GetById(CardInformation card);
    }
}
