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
        public async Task<ActionResult> AddNotice([FromBody] TempMessage message)
        {
            try
            {
                Notice notice = JsonConvert.DeserializeObject<Notice>(message.Content.ToString());
                await _noticeBLL.AddNotice(notice);
                return Ok(notice);
            }
            catch (Exception ex)
            {

                throw new Exception("Invalide Request");
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Notice> GetAll()
        {
            return _noticeBLL.GetAll();
        }

        [HttpPost]
        [Route("SearchNotice")]
        public Task<List<Notice>> SearchZone([FromBody] TempMessage message)
        {
            try
            {
                string noticename = JsonConvert.DeserializeObject<string>(message.Content.ToString());

                return _noticeBLL.Search(noticename);
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        [HttpPost]
        [Route("UpdateNotice")]
        public async Task<ActionResult> UpdateNotice([FromBody] TempMessage message)
        {
            try
            {
                Notice notice = JsonConvert.DeserializeObject<Notice>(message.Content.ToString());
                await _noticeBLL.UpdateNotice(notice);
                return Ok(notice);
            }
            catch (Exception ex)
            {

                throw new Exception("Failed To Update");
            }
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromBody] TempMessage message)
        {
            try
            {
                Notice notice = JsonConvert.DeserializeObject<Notice>(message.Content.ToString());
                return Ok(await _noticeBLL.GetById(notice));
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }
    }
}
