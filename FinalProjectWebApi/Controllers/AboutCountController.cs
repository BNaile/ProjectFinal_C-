using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutCountController : ControllerBase
    {
        private readonly IAboutCountService _aboutCountService;

        public AboutCountController(IAboutCountService aboutCountService)
        {
            _aboutCountService = aboutCountService;
        }
        [HttpGet("GetAboutCounts")]
         public IActionResult GetAboutCounts()
        {
            var result= _aboutCountService.GetAll();
            if(result.IsSuccess)
            {
                return Ok(result);
            }
               
            return BadRequest();
        }
        [HttpPost("PostAboutCount")]
        public IActionResult PostAboutCount(AboutCountCreateDto dto)
        {
            var result = _aboutCountService.Add(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("PutAboutCount")]
        public IActionResult PutAboutCount(AboutCountUpdateDto dto)
        {
            var result = _aboutCountService.UpDate(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteAboutCount")]
        public IActionResult DeleteAboutCount(AboutCountDto dto)
        {
            var result = _aboutCountService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
