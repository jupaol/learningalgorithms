using System.Threading.Tasks;
using Api.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.V1.Controllers
{
	// No need to use try-catch to log, this is handled automatically by the middleware
	[ApiController]
	[ApiVersion("1.0")]
	[Produces("application/json")]
	[Route("api/" + GlobalSettings.ServiceName + "/v{api-version:apiVersion}/[controller]")]
	public class HeartBeatController : ControllerBase
	{
		[HttpGet]
		[Route("ping")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public Task<ActionResult<bool>> PingAsync()
		{
			return Task.FromResult<ActionResult<bool>>(Ok(true));
		}
	}
}
