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
    [Route("api/PaymentGetway")]
    [ApiController]
    public class PaymentGetwayController : ControllerBase
    {
        private readonly IPaymentGetwayBLLManager _paymentGetwayBLL;
        public PaymentGetwayController(IPaymentGetwayBLLManager paymentGetwayBLL)
        {
            _paymentGetwayBLL = paymentGetwayBLL;
        }

        [HttpPost("Card")]
        public async Task<ActionResult> GetCard([FromBody] TempMessage message)
        {
            CardInformation cardInformation = JsonConvert.DeserializeObject<CardInformation>(message.Content.ToString());

            return Ok(_paymentGetwayBLL.GetCardInformation(cardInformation));
        }

        [HttpPost("MobileBanking")]
        public async Task<ActionResult> GetMobileBanking([FromBody]  TempMessage message)
        {
            MobileBanking mobileBanking = JsonConvert.DeserializeObject<MobileBanking>(message.Content.ToString());

            return Ok(_paymentGetwayBLL.GetMobileBankingInformation(mobileBanking));
        }


    }
}
