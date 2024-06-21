using Business.Abstract;
using Entities.Concrete.Dto;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessCatService _businessService;
        public BusinessController(IBusinessCatService businessService)
        {
            _businessService = businessService;
        }
        [HttpGet("GetBusiness")]
        public IActionResult GetBusiness()
        {
            var result = _businessService.GetAll();  
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("PostBusiness")]
        public IActionResult PostBusiness(BusinessCatCreateDto dto)
        {
            var result = _businessService.Add(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("PutBusiness")]
        public IActionResult PutBusiness(BusinessCatUpdateDto dto)
        {
            var result = _businessService.UpDate(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteBusiness")]
        public IActionResult DeleteBusiness(BusinessCatDto dto)
        {
            var result = _businessService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
