using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectricBillPayment.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.DTO;
using Newtonsoft.Json;

namespace BillPayment.Service.Controllers
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

        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                var res = _userBLL.AddUser(user);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
