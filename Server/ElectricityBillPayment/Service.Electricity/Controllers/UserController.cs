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
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLLManager userBLLManager;
        public UserController(IUserBLLManager userBLLManager)
        {
            this.userBLLManager = userBLLManager;
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> AddUser([FromBody] TempMessage message)
        {
            try
            {

                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());
                
                await this.userBLLManager.AddUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] TempMessage message)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());

                
                await this.userBLLManager.UpdateUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPost]
        [Route("SearchUser")]
        public Task<List<User>> SearchUser([FromBody] TempMessage message)
        {
            try
            {
                string username = JsonConvert.DeserializeObject<string>(message.Content.ToString());

                return this.userBLLManager.Search(username);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("GetbyID")]
        public async Task<ActionResult> GetbyID([FromBody] TempMessage message)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<int>(message.Content.ToString());

                return Ok(await this.userBLLManager.GetByID(user));

            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll([FromBody] TempMessage message)
        {
            try
            {

                return Ok(await this.userBLLManager.GetAll());
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpGet]
        [Route("GetAllMeterReader")]
        public List<User> GetAllMeterReader()
        {
            try
            {
                return this.userBLLManager.GetAllMeterReader();
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        [HttpGet]
        [Route("Gets")]

        public string Gets()
        {

            return "hello";
        }
        //[HttpPost]
        //[Route("AddUser")]
        //public void AddUser([FromBody]User user)
        //{
        //    _userBLLManager.AddUser(user);
        //}

    }
}
