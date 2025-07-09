using eApp.Models.DTOs;
using eApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("latest-records")]
        public async Task<ActionResult<ICollection<DashboardDTO>>> GetLatestRecords()
        {
            var latestRecords = await _dashboardService.GetLatestRecords();
            return Ok(latestRecords);
        }
    }
}