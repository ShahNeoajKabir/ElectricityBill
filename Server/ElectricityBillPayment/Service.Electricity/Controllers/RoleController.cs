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
using Service.Electricity.Handler;

namespace Service.Electricity.Controllers
{
    //[Authorize]
    [Route("api/Role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleBLLManager _roleBLL;
        public RoleController(IRoleBLLManager roleBLL)
        {
            _roleBLL = roleBLL;
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<ActionResult> AddRole([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];

                Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
                role.CreatedBy = loginedUser.UserName;
                await _roleBLL.AddRole(role);
                return Ok( role);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Role> GetAll()
        {
            var loginedUser = (User)HttpContext.Items["User"];
            return _roleBLL.GetAll();
        }


        [HttpPost]
        [Route("SearchRole")]
        public Task<List<Role>> SearchZone([FromBody] TempMessage message)
        {
            try
            {
                string rolename = JsonConvert.DeserializeObject<string>(message.Content.ToString());

                return _roleBLL.Search(rolename);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPost]
        [Route("UpdateRole")]
        public async Task<ActionResult> UpdateRole([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
                role.UpdatedBy = loginedUser.UserName;
                await _roleBLL.UpdateRole(role);
                return Ok(role);
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
            Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
            return Ok(await _roleBLL.GetByID(role));
        }
    }
}
