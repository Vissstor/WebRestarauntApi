﻿using Microsoft.AspNetCore.Mvc;
using RestarauntBLL.Models.Portion;
using RestarauntBLL.Services.Abstract;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortionController : Controller
    {
        private readonly IPortionService _portionService;
        public PortionController(IPortionService portionService)
        {
            _portionService = portionService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PortionDto>>> GetPortionAsync()
        {
            try
            {
                var ingredients = await _portionService.GetAllPortionAsync();
                return Ok(ingredients);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePortion(long id,PortionForDishDto por)
        {
            await _portionService.UpdatePortionAsync(id, por);
            return NoContent();
        }
    }
}
