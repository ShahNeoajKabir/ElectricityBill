using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.DTO;
using SecurityBLLManager;

namespace Service.Portal.Controllers
{
    [Route("api/Support")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportBLLManager _supportBLL;
        public SupportController(ISupportBLLManager supportBLL)
        {
            _supportBLL = supportBLL;
        }

        [HttpPost]
        [Route("AddSupport")]

        public Support AddSupport([FromBody]Support support)
        {
            try
            {
                _supportBLL.AddSupport(support);
                return support;
            }
            catch (Exception)
            {

                throw new Exception("Inavlide Request");
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Support> GetAll()
        {
            return _supportBLL.GetAll();
        }

        [HttpPost]
        [Route("UpdateSupport")]
        public Support UpdateSupport([FromBody] Support support)
        {
            try
            {
                _supportBLL.UpdateSupport(support);
                return support;
            }
            catch (Exception)
            {

                throw new Exception("Invalide Request");
            }
        }


        [HttpPost]
        [Route("GetById")]

        public Support GetById([FromBody]Support support)
        {
            return _supportBLL.GetById(support);
             
        }
    }
}
