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
    [Route("api/ZoneAssign")]
    [ApiController]
    public class ZoneAssignController : ControllerBase
    {
        private readonly IZoneAssignBLLManager _bLLManager;
        public ZoneAssignController(IZoneAssignBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }
        [HttpPost]
        [Route("AssignZone")]
        public async Task<ActionResult>AssignZone([FromBody]TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                ZoneAssign zoneAssign = JsonConvert.DeserializeObject<ZoneAssign>(message.Content.ToString());
                zoneAssign.CreatedBy = loginedUser.UserName;
                await _bLLManager.AssignZone(zoneAssign);
                return Ok(zoneAssign);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAll")]

        public List<ZoneAssign> GetAll()
        {
            return _bLLManager.GetAll();
        }

        [HttpPost]
        [Route("UpdateZoneAssign")]
        public async Task<ActionResult>UpdateZoneAssign([FromBody]TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                ZoneAssign zoneAssign = JsonConvert.DeserializeObject<ZoneAssign>(message.Content.ToString());
                zoneAssign.UpdatedBy = loginedUser.UserName;
                await _bLLManager.UpdateZoneAssign(zoneAssign);
                return Ok(zoneAssign);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult>GetById([FromBody] TempMessage message)
        {
            try
            {
                ZoneAssign zoneAssign = JsonConvert.DeserializeObject<ZoneAssign>(message.Content.ToString());
                return Ok(await _bLLManager.GetById(zoneAssign));
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("Search")]
        public Task<List<ZoneAssign>> SearchZone([FromBody] TempMessage message)
        {
            try
            {
                string UserName = JsonConvert.DeserializeObject<string>(message.Content.ToString());

                return _bLLManager.Search(UserName);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
