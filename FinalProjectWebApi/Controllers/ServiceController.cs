using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicePackage _servicepackageService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceController(IServicePackage servicepackageService, IWebHostEnvironment webHostEnvironment)
        {
            _servicepackageService = servicepackageService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("GetService")]
        public IActionResult GetService()
        {
            var result = _servicepackageService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("PostService")]
        public IActionResult PostPosition([FromForm] ServicePackageCreateDto dto, IFormFile photoUrl)
        {
            var result = _servicepackageService.Add(dto, photoUrl, _webHostEnvironment.WebRootPath);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("PutService")]
        public IActionResult PutService([FromForm] ServicePackageUpdateDto dto, IFormFile photoUrl)
        {
            var result = _servicepackageService.UpDate(dto, photoUrl, _webHostEnvironment.WebRootPath);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteService")]
        public IActionResult DeleteService(ServicePackageDto dto)
        {
            var result = _servicepackageService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
