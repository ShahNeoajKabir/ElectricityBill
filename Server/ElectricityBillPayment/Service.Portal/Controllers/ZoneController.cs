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
        public Zone AddZone([FromBody] TempMessage message)
        {
            try
            {
                Zone zone = JsonConvert.DeserializeObject<Zone>(message.Content.ToString());
                _zoneBLL.AddZone(zone);
                return zone;
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
        public Zone UpdateZone([FromBody] TempMessage message)
        {
            try
            {
                Zone zone = JsonConvert.DeserializeObject<Zone>(message.Content.ToString());
                _zoneBLL.UpdateZone(zone);
                return zone;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("SearchZone")]
        public List<Zone> SearchZone([FromBody] TempMessage message)
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
        public Zone GetById([FromBody]TempMessage message)
        {
            Zone zone = JsonConvert.DeserializeObject<Zone>(message.Content.ToString());
            return _zoneBLL.GetById(zone);
        }
    }
}
