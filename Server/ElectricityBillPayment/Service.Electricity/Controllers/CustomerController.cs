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
                await _customerBLLManager.AddCustomer(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("UpdateCustomer")]
        public async Task<ActionResult> UpdateCustomer([FromBody] TempMessage message)
        {
            try
            {
                Customer customer = JsonConvert.DeserializeObject<Customer>(message.Content.ToString());

                await _customerBLLManager.UpdateUser(customer);
                return Ok( customer);
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
                Customer customer = JsonConvert.DeserializeObject<Customer>(message.Content.ToString());

                return Ok(await _customerBLLManager.GetById(customer));

            }
            catch (Exception ex)
            {

                throw;
            }
        }



        [HttpGet]
        [Route("GetAll")]
        public Task<List<Customer>> GetAll()
        {
            try
            {
                return _customerBLLManager.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }




        }
        [HttpGet]
        [Route("GetAllPendingCustomer")]
        public List<Customer> GetAlll()
        {
            try
            {
                return _customerBLLManager.GetAllPendingCustomer();
            }
            catch (Exception ex)
            {

                throw;
            }




        }
        [HttpGet]
        [Route("GetAllPending")]
        public Task<List<Customer>> GetAllPending()
        {
            try
            {
                return _customerBLLManager.GetAllPending();
            }
            catch (Exception ex)
            {

                throw;
            }




        }


        [HttpPost]
        [Route("SearchCustomer")]
        public Task<List<Customer>> SearchZone([FromBody] TempMessage message)
        {
            try
            {
                string customername = JsonConvert.DeserializeObject<string>(message.Content.ToString());

                return _customerBLLManager.Search(customername);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
