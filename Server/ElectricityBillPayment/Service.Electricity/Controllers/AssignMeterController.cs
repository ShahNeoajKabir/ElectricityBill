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
using Service.Electricity.MailConfig;

namespace Service.Electricity.Controllers
{
    [Route("api/AssignMeter")]
    [ApiController]
    public class AssignMeterController : ControllerBase
    {
        private readonly IMeterAssignBLLmanager _bLLmanager;
        private readonly IMailer _mailer;
        public AssignMeterController(IMeterAssignBLLmanager bLLmanager, IMailer mailer)
        {
            _bLLmanager = bLLmanager;
            _mailer = mailer;
        }

        [HttpPost]
        [Route("AssignMeter")]
        public async Task<ActionResult> AssignMeter([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                
                MeterAssign meter = JsonConvert.DeserializeObject<MeterAssign>(message.Content.ToString());

                Customer customer = new Customer();
                meter.CreatedBy = loginedUser.UserName;
                var assign= await _bLLmanager.AssignMeter(meter);
                if (assign.MeterAssignId > 0)
                {
                    await _mailer.SendEmailAsync(customer.Email, "Request Accepted", "now you are authurized for login" + "Your Emai Is" + customer.Email + "Your Password Is 123456");
                    return Ok(assign);
                }


                return Ok( meter);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<MeterAssign> GetAll()
        {
            var loginedUser = (User)HttpContext.Items["User"];

            return _bLLmanager.GetAll(loginedUser.UserId);
        }


        [HttpPost]
        [Route("SearchMeterAssign")]
        public Task<List<MeterAssign>> SearchZone([FromBody] TempMessage message)
        {
            try
            {
                string meternumber = JsonConvert.DeserializeObject<string>(message.Content.ToString());

                return _bLLmanager.Search(meternumber);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPost]
        [Route("UpdateAssign")]
        public async Task<ActionResult> UpdateAssign([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                MeterAssign meter = JsonConvert.DeserializeObject<MeterAssign>(message.Content.ToString());
                meter.UpdatedBy = loginedUser.UserName;
                await _bLLmanager.UpdateAssign(meter);
                return Ok(meter);
            }
            catch (Exception ex)
            {

                throw new Exception("Failed To UPdate");
            }
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromBody] TempMessage message)
        {
            MeterAssign meter = JsonConvert.DeserializeObject<MeterAssign>(message.Content.ToString());
            return Ok(await _bLLmanager.GetById(meter));
        }
    }
}
