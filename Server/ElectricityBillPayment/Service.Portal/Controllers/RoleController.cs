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
        public Role AddRole([FromBody] TempMessage message)
        {
            try
            {
                Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
                _roleBLL.AddRole(role);
                return role;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Role>GetAll()
        {
            return _roleBLL.GetAll();
        }

        [HttpPost]
        [Route("UpdateRole")]
        public Role UpdateRole([FromBody] TempMessage message)
        {
            try
            {
                Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
                _roleBLL.UpdateRole(role);
                return role;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("GetById")]
        public Role GetById([FromBody] TempMessage message)
        {
            Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
            return _roleBLL.GetByID(role);
        }
    }
}
