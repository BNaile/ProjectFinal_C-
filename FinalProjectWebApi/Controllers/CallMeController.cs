using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallMeController : ControllerBase
    {
        private readonly ICallMeService _callmeService;

        public CallMeController(ICallMeService callmeService)
        {
            _callmeService = callmeService;
        }
        [HttpGet("GetCallMe")]
        public IActionResult GetCallMe()
        {
            var result = _callmeService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("PostCallMe")]
        public IActionResult PostCallMe(CallMeCreateDto dto)
        {
            var result = _callmeService.Add(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("PutCallMe")]
        public IActionResult PutCallMe(CallMeUpdateDto dto)
        {
            var result = _callmeService.UpDate(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteCallMe")]
        public IActionResult DeleteCallMe(CallMeDto dto)
        {
            var result = _callmeService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
