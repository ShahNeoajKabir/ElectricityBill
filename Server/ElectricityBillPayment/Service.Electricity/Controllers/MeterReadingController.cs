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
    [Route("api/MeterReading")]
    [ApiController]
    public class MeterReadingController : ControllerBase
    {
        private readonly IMeterReadingBLLManager _bLLManager;
        public MeterReadingController(IMeterReadingBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        [HttpPost]
        [Route("AddMeterReading")]
        public async Task<ActionResult> AddMeterReading([FromBody] TempMessage message, int ReaderId)
        {
            try
            {
                VMAddMeterReading meterReadingTable = JsonConvert.DeserializeObject<VMAddMeterReading>(message.Content.ToString());
                await _bLLManager.AddMeterReading(meterReadingTable, ReaderId);
                return Ok(meterReadingTable);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<MeterReadingTable> GetAll()
        {
            return _bLLManager.GetAll();
        }


        //[HttpPost]
        //[Route("SearchMeterAssign")]
        //public Task<List<MeterAssign>> SearchZone([FromBody] TempMessage message)
        //{
        //    try
        //    {
        //        string meternumber = JsonConvert.DeserializeObject<string>(message.Content.ToString());

        //        return _bLLmanager.Search(meternumber);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }


        //}

        [HttpPost]
        [Route("UpdateMeterReading")]
        public async Task<ActionResult> UpdateMeterReading([FromBody] TempMessage message)
        {
            try
            {
                MeterReadingTable meter = JsonConvert.DeserializeObject<MeterReadingTable>(message.Content.ToString());
                await _bLLManager.UpdateMeterReading(meter);
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
            MeterReadingTable meter = JsonConvert.DeserializeObject<MeterReadingTable>(message.Content.ToString());
            return Ok(await _bLLManager.GetById(meter));
        }
    }
}
