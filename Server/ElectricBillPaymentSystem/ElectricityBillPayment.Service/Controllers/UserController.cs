using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectricBillPayment.BLL;
using Microsoft.AspNetCore.Mvc;
using ModelClass.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityBillPayment.Service.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLLManager _userBLL;
        public UserController(IUserBLLManager userBLL)
        {
            _userBLL = userBLL;
        }


        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            try
            {
                return Ok(await _userBLL.AddUser(user));
            }
            catch (Exception )
            {

                throw new Exception("Sorry");
            }
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
    }
}
