using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.DTO;
using SecurityBLLManager;

namespace Service.Portal.Controllers
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
        public MeterTable AddMeter([FromBody] MeterTable meter)
        {
            try
            {
                _meterBLL.AddMeter(meter);
                return meter;
            }
            catch (Exception)
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
        [Route("UpdateMeter")]
        public MeterTable UpdateMeter([FromBody] MeterTable meter)
        {
            try
            {
                _meterBLL.UpdateMeter(meter);
                return meter;
            }
            catch (Exception)
            {

                throw new Exception("Failed To Update");
            }
        }

        [HttpPost]
        [Route("GetById")]
        public MeterTable GetById([FromBody] MeterTable meter)
        {
            return _meterBLL.GetById(meter);
        }
    }
}
