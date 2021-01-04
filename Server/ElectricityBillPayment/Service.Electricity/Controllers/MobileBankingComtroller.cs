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
    [Route("api/MobileBanking")]
    [ApiController]
    public class MobileBankingComtroller : ControllerBase
    {
        private readonly IMobileBankingBLLmanager _bLLmanager;
        public MobileBankingComtroller(IMobileBankingBLLmanager bLLmanager)
        {
            _bLLmanager = bLLmanager;
        }

        [HttpPost]
        [Route("AddMobile")]
        public async Task<ActionResult>AddMobile([FromBody]TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                MobileBanking mobile = JsonConvert.DeserializeObject<MobileBanking>(message.Content.ToString());
               
                await _bLLmanager.AddMobile(mobile);
                return Ok(mobile);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<MobileBanking> GetAll()
        {
            return _bLLmanager.GetAll();
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult>GetById([FromBody]TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                MobileBanking mobile = JsonConvert.DeserializeObject<MobileBanking>(message.Content.ToString());
                return Ok(await _bLLmanager.GetById(mobile));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
