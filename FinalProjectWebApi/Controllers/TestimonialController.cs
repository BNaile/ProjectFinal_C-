using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TestimonialController(ITestimonialService testimonialService, IWebHostEnvironment webHostEnvironment)
        {
            _testimonialService = testimonialService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial()
        {
            var result = _testimonialService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("PostTestimonial")]
        public IActionResult Create([FromForm] TestimonialCreateDto dto, IFormFile Photourl)
        {
            var result = _testimonialService.Add(dto, Photourl, _webHostEnvironment.WebRootPath);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();

        }
        [HttpPut("PutTestimonial")]
        public IActionResult PutTestimonial([FromForm] TestimonialUpdateDto dto, IFormFile Photourl)
        {
            var result = _testimonialService.UpDate(dto, Photourl, _webHostEnvironment.WebRootPath);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteTestimonial")]
        public IActionResult DeleteTestimonial(TestimonialDto dto)
        {
            var result = _testimonialService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
