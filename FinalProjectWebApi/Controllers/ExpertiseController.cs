using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertiseController : ControllerBase
    {
        private readonly IExpertiseService _expertiseService;

        public ExpertiseController(IExpertiseService expertiseService)
        {
            _expertiseService = expertiseService;
        }
        [HttpGet("GetExpertise")]
        public IActionResult GetExpertise()
        {
            var result = _expertiseService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("PostExpertise")]
        public IActionResult PostExpertise(ExpertiseCreateDto dto)
        {
            var result = _expertiseService.Add(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("PutExpertise")]
        public IActionResult PutExpertise(ExpertiseUpdateDto dto)
        {
            var result = _expertiseService.UpDate(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteExpertise")]
        public IActionResult DeleteExpertise(ExpertiseDto dto)
        {
            var result = _expertiseService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
