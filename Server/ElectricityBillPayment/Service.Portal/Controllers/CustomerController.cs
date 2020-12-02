using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityBLLManager;

using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ModelClass.DTO;
using ModelClass.ViewModel;

namespace Service.Portal.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBLLManager _customerBLLManager;
        public CustomerController(ICustomerBLLManager customerBLLManager)
        {
            _customerBLLManager = customerBLLManager;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<ActionResult> Registration([FromBody] TempMessage message)
        {
            try
            {

                Customer customer = JsonConvert.DeserializeObject<Customer>(message.Content.ToString());
                _customerBLLManager.AddCustomer(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("UpdateCustomer")]
        public Customer UpdateCustomer([FromBody] Customer customer)
        {
            try
            {

                _customerBLLManager.UpdateUser(customer);
                return customer;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("GetbyID")]
        public Customer GetbyID([FromBody] TempMessage message)
        {
            try
            {
                Customer customer = JsonConvert.DeserializeObject<Customer>(message.Content.ToString());

                return _customerBLLManager.GetById(customer);

            }
            catch (Exception ex)
            {

                throw;
            }


            //}
            //[HttpGet]
            //[Route("GetAll")]
            //public List<User> GetAll()
            //{
            //    try
            //    {
            //        return this.userBLLManager.GetAll();
            //    }
            //    catch (Exception ex)
            //    {

            //        throw;
            //    }


            //}

            //[HttpGet]
            //[Route("Gets")]

            //public string Gets()
            //{

            //    return "hello";
            //}
            //[HttpPost]
            //[Route("AddUser")]
            //public void AddUser([FromBody]User user)
            //{
            //    _userBLLManager.AddUser(user);
            //}

        }
    }
}