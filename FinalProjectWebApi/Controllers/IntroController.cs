using Business.Abstract;
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
        [HttpPost]
        public IActionResult Create(IntroCreateDto dto, IFormFile photoUrl)
        {
            var result = _introService.Add(dto, photoUrl, _webHostEnvironment.WebRootPath);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();

        }
    }
}
