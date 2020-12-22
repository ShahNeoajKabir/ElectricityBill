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
    [Route("api/RolePermission")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionBLLManager _bLLManager;
        public RolePermissionController(IRolePermissionBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        [HttpPost]
        [Route("AddRolePermission")]
        public async Task<ActionResult>AddRolePermission([FromBody]TempMessage message)
        {
            try
            {
                VMRolePermission permission = JsonConvert.DeserializeObject<VMRolePermission>(message.Content.ToString());
                await _bLLManager.AddRolePermission(permission);
                return Ok(permission);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("AddURL")]
        public async Task<ActionResult> AddUrl([FromBody] TempMessage message)
        {
            try
            {
                URL url = JsonConvert.DeserializeObject<URL>(message.Content.ToString());
                await _bLLManager.AddUrl(url);
                return Ok(url);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<URL> GetAll()
        {
            return _bLLManager.GetAll();
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult>GetById([FromBody] TempMessage message)
        {
            RolePermission permission = JsonConvert.DeserializeObject<RolePermission>(message.Content.ToString());
            return Ok(await _bLLManager.GetById(permission));
        }
    }
}
