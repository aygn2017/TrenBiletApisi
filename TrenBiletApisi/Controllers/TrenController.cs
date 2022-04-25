using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrenBiletApisi.Model.vm;
using TrenBiletApisi.Services;

namespace TrenBiletApisi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public TrainController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult Reservation(RequestViewModel request)
        {
            var resp = _reservationService.Reservation(request);
            if (resp != null)
            {
                return Ok(resp);
            }
            return NotFound();
        }
    }
}