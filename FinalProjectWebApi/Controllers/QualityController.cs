using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualityController : ControllerBase
    {
        private readonly IQualityService _qualityService;

        public QualityController(IQualityService qualityService)
        {
            _qualityService = qualityService;
        }
        [HttpGet("GetQuality")]
        public IActionResult GetQuality()
        {
            var result = _qualityService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("PostQuality")]
        public IActionResult PostQuality(QualityCreateDto dto)
        {
            var result = _qualityService.Add(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("PutQuality")]
        public IActionResult PutQuality(QualityUpdateDto dto)
        {
            var result = _qualityService.UpDate(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteQuality")]
        public IActionResult DeleteQuality(QualityDto dto)
        {
            var result = _qualityService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
