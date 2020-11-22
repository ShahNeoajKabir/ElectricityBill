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
    [Route("api/Notice")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
        private readonly INoticeBLLManager _noticeBLL;
        public NoticeController(INoticeBLLManager noticeBLL)
        {
            _noticeBLL = noticeBLL;
        }

        [HttpPost]
        [Route("AddNotice")]
        public Notice AddNotice([FromBody] Notice notice)
        {
            try
            {
                _noticeBLL.AddNotice(notice);
                return notice;
            }
            catch (Exception)
            {

                throw new Exception("Invalide Request");
            }
        }
    }
}
