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
    [Route("api/UnitPrice")]
    [ApiController]
    public class UnitPriceController : ControllerBase
    {
        private readonly IUnitPriceBLLManager _bLLManager;
        public UnitPriceController(IUnitPriceBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost]
        [Route("AddUnitPrice")]
        public async Task<ActionResult>AddUnitPrice([FromBody]TempMessage message)
        {
            try
            {
                UnitPrice unitPrice = JsonConvert.DeserializeObject<UnitPrice>(message.Content.ToString());
                await _bLLManager.AddUnitPrice(unitPrice);
                return Ok(unitPrice);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("UpdateUnitPrice")]
        public async Task<ActionResult> UpdateUnitPrice([FromBody] TempMessage message)
        {
            try
            {
                UnitPrice unitPrice = JsonConvert.DeserializeObject<UnitPrice>(message.Content.ToString());
                await _bLLManager.UpdateUnitPrice(unitPrice);
                return Ok(unitPrice);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromBody] TempMessage message)
        {
            try
            {
                UnitPrice unitPrice = JsonConvert.DeserializeObject<UnitPrice>(message.Content.ToString());
                
                return Ok(await _bLLManager.GetById(unitPrice));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<UnitPrice> GetAll()
        {
            return _bLLManager.GetAll();
        }
    }
}
