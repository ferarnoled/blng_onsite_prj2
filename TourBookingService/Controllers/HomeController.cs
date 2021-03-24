using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TourBooking.Core.Services.Interfaces;

namespace TourBooking.Api.Controllers
{
    [Route("home")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        private readonly ILogger<HomeController> logger;

        public HomeController(IHomeService homeService, ILogger<HomeController> logger)
        {
            this.homeService = homeService;
            this.logger = logger;
        }

        [HttpGet("homes/v1")]
        public async Task<IActionResult> Homes()
        {
            try
            {
                var homes = await homeService.GetAll();
                return Ok(homes);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpGet("isSelfTourAllowed/v1")]
        public async Task<IActionResult> IsSelfTourAllowed(string id)
        {
            try
            {
                var value = await homeService.IsSelfTourAllowed(id);

                return Ok(value);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }
    }
}
