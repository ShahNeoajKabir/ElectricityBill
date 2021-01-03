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
    [Route("api/Zone")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneBLLManager _zoneBLL;
        public ZoneController(IZoneBLLManager zoneBLL)
        {
            _zoneBLL = zoneBLL;
        }

        [HttpPost]
        [Route("AddZone")]
        public async Task<ActionResult> AddZone([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                Zone zone = JsonConvert.DeserializeObject<Zone>(message.Content.ToString());
                zone.CreatedBy = loginedUser.UserName;
                await _zoneBLL.AddZone(zone);
                return Ok(zone);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpGet]
        [Route("GetAll")]
        public List<Zone> GetAll()
        {
            return _zoneBLL.GetAll();
        }

        [HttpPost]
        [Route("UpdateZone")]
        public async Task<ActionResult> UpdateZone([FromBody] TempMessage message)
        {
            try
            {
                Zone zone = JsonConvert.DeserializeObject<Zone>(message.Content.ToString());
                var loginedUser = (User)HttpContext.Items["User"];
                zone.UpdatedBy = loginedUser.UserName;
                await _zoneBLL.UpdateZone(zone);
                return Ok(zone);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("SearchZone")]
        public Task<List<Zone>> SearchZone([FromBody] TempMessage message)
        {
            try
            {
                string zonename = JsonConvert.DeserializeObject<string>(message.Content.ToString());

                return _zoneBLL.Search(zonename);
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
            Zone zone = JsonConvert.DeserializeObject<Zone>(message.Content.ToString());
            return Ok(await _zoneBLL.GetById(zone));
        }
    }
}
