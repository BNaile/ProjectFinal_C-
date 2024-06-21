using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntroController : ControllerBase
    {
        private readonly IIntroService _introService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IntroController(IIntroService introService, IWebHostEnvironment webHostEnvironment)
        {
            _introService = introService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetIntro")]
        public IActionResult GetIntro()
        {
            var result = _introService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("PostIntro")]
        public IActionResult Create([FromForm] IntroCreateDto dto, IFormFile photoUrl)
        {
            var result = _introService.Add(dto, photoUrl, _webHostEnvironment.WebRootPath);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();

        }
        [HttpPut("PutIntro")]
        public IActionResult PutIntro([FromForm] IntroUpdateDto dto, IFormFile photoUrl)
        {
            var result = _introService.UpDate(dto, photoUrl, _webHostEnvironment.WebRootPath);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteIntro")]
        public IActionResult DeleteIntro(IntroDto dto)
        {
            var result = _introService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
