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
    [Route("api/UserRole")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleBLLManager _bLLManager;
        public UserRoleController(IUserRoleBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        [HttpPost]
        [Route("AddUserRole")]
        public UserRole AddUserRole([FromBody] TempMessage message)
        {
            try
            {
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(message.Content.ToString());
                _bLLManager.AddUserRole(userRole);
                return userRole;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("GetAll")]
        public List<UserRole> GetAll()
        {
            return _bLLManager.GetAll();
        }


        [HttpPost]
        [Route("SearchUserRole")]
        public List<UserRole> SearchUser([FromBody] TempMessage message)
        {
            try
            {
                string username = JsonConvert.DeserializeObject<string>(message.Content.ToString());

                return _bLLManager.Search(username);
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        [HttpPost]
        [Route("UpdateUserRole")]
        public UserRole UpdateUserRole([FromBody]TempMessage message)
        {
            try
            {
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(message.Content.ToString());
                _bLLManager.UpdateUserRole(userRole);
                return userRole;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("GetById")]
        public UserRole GetById([FromBody]TempMessage message)
        {
            try
            {
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(message.Content.ToString());
                return _bLLManager.GetById(userRole);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
