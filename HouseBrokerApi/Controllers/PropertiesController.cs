using HouseBrokerApp.Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseBrokerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly GetAllPropertiesQuery _getAllPropertiesQuery;

        public PropertiesController(GetAllPropertiesQuery getAllPropertiesQuery)
        {
            _getAllPropertiesQuery = getAllPropertiesQuery;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var properties = await _getAllPropertiesQuery.ExecuteAsync();
            return Ok(properties);
        }
    }
}
