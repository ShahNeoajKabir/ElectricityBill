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
        public Customer Registration([FromBody] TempMessage message)
        {
            try
            {

                Customer customer = JsonConvert.DeserializeObject<Customer>(message.Content.ToString());
                _customerBLLManager.AddCustomer(customer);
                return customer;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("UpdateCustomer")]
        public Customer UpdateCustomer([FromBody] TempMessage message)
        {
            try
            {
                Customer customer = JsonConvert.DeserializeObject<Customer>(message.Content.ToString());

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
        }



        [HttpGet]
        [Route("GetAll")]
        public List<Customer> GetAll()
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


        [HttpPost]
        [Route("SearchCustomer")]
        public List<Customer> SearchZone([FromBody] TempMessage message)
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