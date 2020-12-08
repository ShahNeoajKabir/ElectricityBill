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
    [Route("api/AssignMeter")]
    [ApiController]
    public class AssignMeterController : ControllerBase
    {
        private readonly IMeterAssignBLLmanager _bLLmanager;
        public AssignMeterController(IMeterAssignBLLmanager bLLmanager)
        {
            _bLLmanager = bLLmanager;
        }

        [HttpPost]
        [Route("AssignMeter")]
        public async Task<ActionResult> AssignMeter([FromBody] TempMessage message)
        {
            try
            {
                MeterAssign meter = JsonConvert.DeserializeObject<MeterAssign>(message.Content.ToString());
                await _bLLmanager.AssignMeter(meter);
                return Ok( meter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<MeterAssign> GetAll()
        {
            return _bLLmanager.GetAll();
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
                MeterAssign meter = JsonConvert.DeserializeObject<MeterAssign>(message.Content.ToString());
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
