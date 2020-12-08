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
    [Route("api/Support")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportBLLManager _supportBLL;
        public SupportController(ISupportBLLManager supportBLL)
        {
            _supportBLL = supportBLL;
        }

        [HttpPost]
        [Route("AddSupport")]

        public async Task<ActionResult> AddSupport([FromBody] TempMessage message)
        {
            try
            {
                Support support = JsonConvert.DeserializeObject<Support>(message.Content.ToString());
                await _supportBLL.AddSupport(support);
                return Ok(support);
            }
            catch (Exception)
            {

                throw new Exception("Inavlide Request");
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Support> GetAll()
        {
            return _supportBLL.GetAll();
        }


        [HttpPost]
        [Route("SearchSupport")]
        public Task<List<Support>> SearchZone([FromBody] TempMessage message)
        {
            try
            {
                string supportname = JsonConvert.DeserializeObject<string>(message.Content.ToString());

                return _supportBLL.Search(supportname);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPost]
        [Route("UpdateSupport")]
        public async Task<ActionResult> UpdateSupport([FromBody] TempMessage message)
        {
            try
            {
                Support support = JsonConvert.DeserializeObject<Support>(message.Content.ToString());

                await _supportBLL.UpdateSupport(support);
                return Ok(support);
            }
            catch (Exception)
            {

                throw new Exception("Invalide Request");
            }
        }


        [HttpPost]
        [Route("GetById")]

        public async Task<ActionResult> GetById([FromBody] TempMessage message)
        {
            Support support = JsonConvert.DeserializeObject<Support>(message.Content.ToString());

            return Ok(await _supportBLL.GetById(support));

        }
    }
}
