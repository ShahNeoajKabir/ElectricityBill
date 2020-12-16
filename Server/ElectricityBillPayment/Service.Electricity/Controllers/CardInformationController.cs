using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.DTO;
using ModelClass.ViewModel;
using Newtonsoft.Json;
using SecurityBLLManager;

namespace Service.Electricity.Controllers
{
    [Route("api/Card")]
    [ApiController]
    public class CardInformationController : ControllerBase
    {
        private readonly ICardBLLManager _bLLManager;
        public CardInformationController(ICardBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost]
        [Route("AddCard")]

        public async Task<ActionResult>AddCard([FromBody]TempMessage message)
        {
            try
            {
                CardInformation card = JsonConvert.DeserializeObject<CardInformation>(message.Content.ToString());
                await _bLLManager.AddCard(card);
                return Ok(card);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<CardInformation> GetAll()
        {
            return _bLLManager.GetAll();
        }


        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult>GetById([FromBody] TempMessage message)
        {
            try
            {
                CardInformation card = JsonConvert.DeserializeObject<CardInformation>(message.Content.ToString());
                return Ok(await _bLLManager.GetById(card));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
