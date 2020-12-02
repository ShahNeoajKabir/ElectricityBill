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

namespace Service.Portal.Controllers
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
                _bLLmanager.AssignMeter(meter);
                return Ok(meter);
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
        [Route("UpdateAssign")]
        public MeterAssign UpdateAssign([FromBody] MeterAssign meter)
        {
            try
            {
                _bLLmanager.UpdateAssign(meter);
                return meter;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("GetById")]
        public MeterAssign GetById([FromBody] MeterAssign meter)
        {
            return _bLLmanager.GetById(meter);
        }
    }
}
