using FutureSpaceAPI.Application.Commands;
using FutureSpaceAPI.Application.Queries;
using FutureSpaceAPI.Application.Responses;
using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Services;
using FutureSpaceAPI.Hangfire;
using Hangfire;
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
        public async Task<IActionResult> GetLauncher(Guid launcherId)
        {
            var query = new GetLauncherQuery(launcherId);
            LauncherResponse response = await _mediator.Send(query);

            if(response is null)
            {
                NotFound();
            }

            return Ok(response);
        }

        [HttpPut("{launchId}")]
        public async Task<IActionResult> UpdateLauncher(Guid launchId, [FromBody]Launch updatedLaunch)
        {
            var command = new UpdateLauncherCommand(launchId, updatedLaunch);
            var response = await _mediator.Send(command);

            if(response is null)
            {
                NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{launchId}")]
        public async Task<IActionResult> DeleteLauncher(Guid launchId)
        {
            try
            {
                var command = new DeleteLauncherCommand(launchId);
                var response = await _mediator.Send(command);

                if (response is false)
                {
                    NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("launchers")]
        public async Task<IActionResult> GetLaunchers(
            [FromQuery] int page,
            [FromQuery] int pageSize)
        {
            var query = new GetAllLaunchersQuery(page, pageSize);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("RecurringJob")]
        public void RecurringJobs()
        {
            RecurringJob.AddOrUpdate<ILauncherService>(x => x.Execute(), Cron.Minutely);
            return;
        }
    }
}