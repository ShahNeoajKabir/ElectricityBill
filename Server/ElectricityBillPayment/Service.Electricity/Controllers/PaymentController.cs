using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public PaymentController(IPaymentBLLManager paymentBLL)
        {

            _paymentBLL = paymentBLL;
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
                int BillId = JsonConvert.DeserializeObject<int>(message.Content.ToString());
                return Ok(await _paymentBLL.ViewPayment(BillId));
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
