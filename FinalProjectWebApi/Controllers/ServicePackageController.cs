using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePackageController : ControllerBase
    {
        private readonly IServicePackageDescription _servicepackageService;
       
        public ServicePackageController(IServicePackageDescription servicepackageService)
        {
            _servicepackageService = servicepackageService;
           
        }
        [HttpGet("GetServicePackage")]
        public IActionResult GetServicePackage()
        {
            var result = _servicepackageService.GetServiceWithServicePackages();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("PostServicePackage")]
        public IActionResult Create(ServicePackageDescriptionCreateDto dto)
        {
            var result = _servicepackageService.Add(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("PutServicePackage")]
        public IActionResult PutServicePackage( ServicePackageDescriptionUpdateDto dto)
        {
            var result = _servicepackageService.UpDate(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteServicePackage")]
        public IActionResult DeleteServicePackage(ServicePackageDescriptionDto dto)
        {
            var result = _servicepackageService.Delete(dto.İd);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
