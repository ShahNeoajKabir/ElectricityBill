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
using Service.Electricity.MailConfig;

namespace Service.Electricity.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBLLManager _customerBLLManager;
        private readonly IMailer _mailer;
        private readonly ICustomerProfileBLLManager _customerProfileBLL;
        public CustomerController(ICustomerBLLManager customerBLLManager, IMailer mailer, ICustomerProfileBLLManager customerProfileBLL)
        {
            _customerBLLManager = customerBLLManager;
            _mailer = mailer;
            _customerProfileBLL = customerProfileBLL;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<ActionResult> Registration([FromBody] TempMessage message)
        {
            try
            {
                //await _mailer.SendEmailAsync("bappyron@gmail.com", "Test", "Pending Customer");

                Customer customer = JsonConvert.DeserializeObject<Customer>(message.Content.ToString());
                await _mailer.SendEmailAsync(customer.Email, "Registration", "Registration Successful Please Wait for Confirmation");
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
                var loginedUser = (User)HttpContext.Items["User"];
                Customer customer = JsonConvert.DeserializeObject<Customer>(message.Content.ToString());
                customer.UpdatedBy = loginedUser.UserName;
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
            var loginedUser = (User)HttpContext.Items["User"];

            try
            {
                return _customerBLLManager.GetAllPendingCustomer(loginedUser.UserId);
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

        [HttpGet]
        [Route("Profile")]
        public async Task<ActionResult>Profile()
        {
            var loginedUser = (User)HttpContext.Items["User"];

            //int UserId = JsonConvert.DeserializeObject<int>(message.Content.ToString());
            return Ok(await _customerBLLManager.ViewProfile(loginedUser.UserId));
        }
        [HttpGet]
        [Route("ViewBillPaper")]
        public async Task<ActionResult> ViewBillPaper()
        {
            var loginedUser = (User)HttpContext.Items["User"];

            //int UserId = JsonConvert.DeserializeObject<int>(message.Content.ToString());
            return Ok(await _customerBLLManager.ViewBillPaper(loginedUser.UserId));
        }

        [HttpGet("GetCustomerLocation")]
        public async Task<ActionResult> GetCustomerLocation()
        {
            return Ok(await _customerBLLManager.GetAllCustomerLocation());
        }
    }
}
