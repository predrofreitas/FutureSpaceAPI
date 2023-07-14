using FutureSpaceAPI.Application.Commands;
using FutureSpaceAPI.Application.Queries;
using FutureSpaceAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FutureSpaceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LauncherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LauncherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("REST Back-end Challenge 20201209 Running");
        }

        [HttpGet("{launcherId}")]
        public async Task<IActionResult> GetLauncher(int launcherId)
        {
            var query = new GetLauncherQuery(launcherId);
            Launcher launcher = await _mediator.Send(query);

            if(launcher is null)
            {
                NotFound();
            }

            return Ok(launcher);
        }

        [HttpPut("{launchId}")]
        public async Task<IActionResult> UpdateLauncher(int launchId, [FromBody]Launcher updatedLauncher)
        {
            var command = new UpdateLauncherCommand(launchId, updatedLauncher);
            var launcher = await _mediator.Send(command);

            if(launcher is null)
            {
                NotFound();
            }

            return Ok(launcher);
        }

        [HttpDelete("{launchId}")]
        public async Task<IActionResult> DeleteLauncher(int launchId)
        {
            try
            {
                var command = new DeleteLauncherCommand(launchId);
                var launcher = await _mediator.Send(command);

                if (launcher is null)
                {
                    NotFound();
                }

                return Ok(launcher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{page}")]
        public async Task<IActionResult> GetLaunchers(int page)
        {
            var query = new GetLaunchersQuery(page);
            var launchers = await _mediator.Send(query);

            return Ok(launchers);
        }
    }
}
