﻿using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        [HttpGet("GetPosition")]
        public IActionResult GetPosition()
        {
            var result = _positionService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("PostPosition")]
        public IActionResult PostPosition(PositionCreateDto dto)
        {
            var result = _positionService.Add(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("PutPosition")]
        public IActionResult PutPosition(PositionUpdateDto dto)
        {
            var result = _positionService.UpDate(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeletePosition")]
        public IActionResult DeletePosition(PositionDto dto)
        {
            var result = _positionService.Delete(dto.Id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
