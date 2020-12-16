using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.DTO;
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
            return _bLLManager.GetAll();
        }

    }
}
