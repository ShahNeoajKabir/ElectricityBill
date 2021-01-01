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
    [Route("api/Bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillTableBLLManager _bLLManager;
        public BillController(IBillTableBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        [HttpGet]
        [Route("GetAll")]
        public List<BillTable> GetAll()
        {
            var loginedUser = (User)HttpContext.Items["User"];
            if(loginedUser!=null && loginedUser.Role == 3)
            {
                return _bLLManager.GetByCustomer(loginedUser.UserId);

            }
            else
            {
                return _bLLManager.GetAll();

            }
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult>GetById([FromBody]TempMessage message)
        {
            BillTable bill = JsonConvert.DeserializeObject<BillTable>(message.Content.ToString());
            return Ok(await _bLLManager.GetById(bill));
        }

    }
}
