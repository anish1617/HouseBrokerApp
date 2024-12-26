using HouseBrokerApp.Application.Services;
using HouseBrokerApp.Application.Dtos;
using HouseBrokerApp.Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseBrokerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var properties = await _propertyService.GetAllAsync();
            return Ok(properties);
        }

        [HttpPost]
        [Authorize(Roles = "Broker")]
        public async Task<IActionResult> Create(PropertyDto propertyDto)
        {
            await _propertyService.AddAsync(propertyDto);
            return Ok("Property added successfully");
        }
    }
}
