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
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentBLLManager _paymentBLL;
        private readonly IPaymentGetwayBLLManager _paymentGetwayBLL;
        public PaymentController(IPaymentBLLManager paymentBLL, IPaymentGetwayBLLManager paymentGetwayBLL)
        {

            _paymentBLL = paymentBLL;
            _paymentGetwayBLL = paymentGetwayBLL;
        }

        [HttpPost]
        [Route("GetPayment")]

        public async Task<ActionResult>GetPayment([FromBody]TempMessage message)
        {
            try
            {
                int BillId = JsonConvert.DeserializeObject<int>(message.Content.ToString());
                return Ok(await _paymentBLL.ViewPayment(BillId));
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }


        [HttpPost]
        [Route("MakePayment")]

        public async Task<ActionResult> MakePayment([FromBody] TempMessage message)
        {
            try
            {
                VMMakePayment vMMakePayment = JsonConvert.DeserializeObject<VMMakePayment>(message.Content.ToString());
                if (vMMakePayment.PaymentMethod == (int)Common.Electricity.Enum.Enum.PaymentMethod.Card)
                {
                    var cardinformation = _paymentGetwayBLL.GetCardInformation(vMMakePayment.cardInformation);
                    if (cardinformation != null)
                    {
                        if (vMMakePayment.RequestAmount <= cardinformation.Result.Balance)
                        {
                            return Ok(await _paymentBLL.MakePayment(vMMakePayment));
                        }
                        
                    }
                    
                }
                else
                {
                    if (vMMakePayment.PaymentMethod == 2)
                    {
                        vMMakePayment.mobileBanking.MobileBankingType = 1;
                    }
                    else if (vMMakePayment.PaymentMethod == 3)
                    {
                        vMMakePayment.mobileBanking.MobileBankingType = 2;
                    }
                    var mobileinformation = _paymentGetwayBLL.GetMobileBankingInformation(vMMakePayment.mobileBanking);
                    if (mobileinformation != null)
                    {
                        if (vMMakePayment.RequestAmount <= mobileinformation.Result.Balance)
                        {
                            return Ok(await _paymentBLL.MakePayment(vMMakePayment));
                        }
                    }
                }
                return BadRequest("Failed");

                
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var loginedUser = (User)HttpContext.Items["User"];

            return  Ok(await _paymentBLL.GetAll(loginedUser.UserId));
        }
    }
}
