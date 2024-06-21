using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeamController(ITeamService teamService, IWebHostEnvironment webHostEnvironment)
        {
            _teamService = teamService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetTeam")]
        public IActionResult GetTeam()
        {
            var result = _teamService.GetTeamWithPositionCategories();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("PostTeam")]
        public IActionResult Create([FromForm] TeamCreateDto dto, IFormFile photoUrl)
        {
            var result = _teamService.Add(dto, photoUrl, _webHostEnvironment.WebRootPath);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();

        }
        [HttpPut("PutTeam")]
        public IActionResult PutTeam([FromForm] TeamUpdateDto dto, IFormFile photoUrl)
        {
            var result = _teamService.UpDate(dto, photoUrl, _webHostEnvironment.WebRootPath);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteTeam")]
        public IActionResult DeleteTeam(TeamDto dto)
        {
            var result = _teamService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
