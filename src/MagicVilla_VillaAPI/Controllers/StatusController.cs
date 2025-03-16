using MagicVilla_Utility.DTO.Status;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{

    [Route("/api")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StatusResponseDTO))]
        public IActionResult GetAPIStatus()
        {
            return Ok(new StatusResponseDTO { Message = AppConstants.WelcomeMessage });
        }
    }
}
