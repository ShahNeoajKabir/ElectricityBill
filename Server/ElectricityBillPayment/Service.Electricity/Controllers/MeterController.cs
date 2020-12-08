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
    [Route("api/Meter")]
    [ApiController]
    public class MeterController : ControllerBase
    {
        private readonly IMeterBLLManager _meterBLL;
        public MeterController(IMeterBLLManager meterBLL)
        {
            _meterBLL = meterBLL;
        }

        [HttpPost]
        [Route("AddMeter")]
        public async Task<ActionResult> AddMeter([FromBody] TempMessage message)
        {
            try
            {
                MeterTable meter = JsonConvert.DeserializeObject<MeterTable>(message.Content.ToString());
                await _meterBLL.AddMeter(meter);
                return Ok( meter);
            }
            catch (Exception ex)
            {

                throw new Exception("Failed To Add");
            }
        }


        [HttpGet]
        [Route("GetAll")]
        public List<MeterTable> GetAll()
        {
            return _meterBLL.GetAll();

        }

        [HttpPost]
        [Route("SearchMeter")]
        public Task<List<MeterTable>> SearchZone([FromBody] TempMessage message)
        {
            try
            {
                string meternumber = JsonConvert.DeserializeObject<string>(message.Content.ToString());

                return _meterBLL.Search(meternumber);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPost]
        [Route("UpdateMeter")]
        public async Task<ActionResult> UpdateMeter([FromBody] TempMessage message)
        {
            try
            {
                MeterTable meter = JsonConvert.DeserializeObject<MeterTable>(message.Content.ToString());
                await _meterBLL.UpdateMeter(meter);
                return Ok( meter);
            }
            catch (Exception ex)
            {

                throw new Exception("Failed To Update");
            }
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromBody] TempMessage message)
        {
            MeterTable meter = JsonConvert.DeserializeObject<MeterTable>(message.Content.ToString());
            return Ok(await _meterBLL.GetById(meter));
        }
    }
}
