using Microsoft.AspNetCore.Mvc;
using ModelClass.ViewModel;
using SecurityBLLManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Electricity.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardBLLManager _dashboardBLLManager;
        public DashboardController(IDashboardBLLManager dashboardBLLManager)
        {
            _dashboardBLLManager = dashboardBLLManager;
        }
        // GET: api/<DashboardController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DashboardController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("GetDashboardData")]
        public async Task<ActionResult> GetDashboardData()
        {
            try
            {
                var Data = new VmDashboard()
                {
                    ActiveCustomer = await _dashboardBLLManager.ActiveCustomer(),
                    TotalBillAmount = await _dashboardBLLManager.TotalBillAmount(),
                    TotalBillCollectAmount = await _dashboardBLLManager.TotalBillCollectAmount(),
                    CustomerLocations = await _dashboardBLLManager.CustomerLocations(),
                    LastTenTransaction = await _dashboardBLLManager.LastTenTransaction(),
                    TotalRegisteredCustomer = await _dashboardBLLManager.TotalRegisteredCustomer(),
                    TotalUsageUnit = await _dashboardBLLManager.TotalUsageUnit()

                };

                return Ok(Data);
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        // POST api/<DashboardController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DashboardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DashboardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
