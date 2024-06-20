using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PhotoController(IPhotoService photoService, IWebHostEnvironment webHostEnvironment)
        {
            _photoService = photoService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("GetPhoto")]
        public IActionResult GetPhoto()
        {
            var result = _photoService.GetPhotMeWithCategory();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("PostPhoto")]
        public IActionResult Create([FromForm] PhotoCreateDto dto, IFormFile name)
        {
            var result = _photoService.Add(dto, name, _webHostEnvironment.WebRootPath);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("PutPhoto")]
        public IActionResult PutPhoto([FromForm] PhotoUpdateDto dto, IFormFile name)
        {
            var result = _photoService.UpDate(dto, name, _webHostEnvironment.WebRootPath);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeletePhoto")]
        public IActionResult DeletePhoto(PhotoDto dto)
        {
            var result = _photoService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
