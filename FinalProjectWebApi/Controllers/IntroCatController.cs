using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntroCatController : ControllerBase
    {
        private readonly IIntroCatService _introcatService;

        public IntroCatController(IIntroCatService introcatService)
        {
            _introcatService = introcatService;
        }
        [HttpGet("GetIntroCat")]
        public IActionResult GetIntroCat()
        {
            var result = _introcatService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("PostIntroCat")]
        public IActionResult PostIntroCat(IntroCatCreateDto dto)
        {
            var result = _introcatService.Add(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("PutIntroCat")]
        public IActionResult PutIntroCat(IntroCatUpdateDto dto)
        {
            var result = _introcatService.UpDate(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteIntroCat")]
        public IActionResult DeleteIntroCat(IntroCategoryDto dto)
        {
            var result = _introcatService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
