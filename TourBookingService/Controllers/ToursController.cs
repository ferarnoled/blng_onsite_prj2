namespace TourBooking.Api.Controllers
{
	using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    using TourBooking.Core.Services.Interfaces;

    [Route("tours")]
	[ApiController]
	public class ToursController : ControllerBase
	{
		private readonly IHomeService homeService;
        private readonly ISlotService slotService;
        private readonly ILogger<ToursController> logger;

        public ToursController(IHomeService homeService, ILogger<ToursController> logger, ISlotService slotService)
        {
			this.homeService = homeService;
            this.logger = logger;
            this.slotService = slotService;
        }


        [HttpGet("slots/v1")]
        public async Task<IActionResult> Slots(string id)
        {
            try
            {
                var slots = await this.slotService.GetSlots(id);
                return Ok(slots);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }
    }
}
