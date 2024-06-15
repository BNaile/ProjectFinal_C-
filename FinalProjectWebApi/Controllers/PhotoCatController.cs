using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoCatController : ControllerBase
    {
        private readonly IPhotoCategoryService _photocatService;

        public PhotoCatController(IPhotoCategoryService photocatService)
        {
            _photocatService = photocatService;
        }
        [HttpGet("GetPhotoCat")]
        public IActionResult GetPhotoCat()
        {
            var result = _photocatService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("PostPhotoCat")]
        public IActionResult PostPhotoCat(PhotoCategoryCreateDto dto)
        {
            var result = _photocatService.Add(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("PutPhotoCat")]
        public IActionResult PutPhotoCat(PhotoCategoryUpdateDto dto)
        {
            var result = _photocatService.UpDate(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeletePhotoCat")]
        public IActionResult DeletePhotoCat(PhotoCategoryDto dto)
        {
            var result = _photocatService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
