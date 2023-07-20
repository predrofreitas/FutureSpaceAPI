using FutureSpaceAPI.Application.Commands;
using FutureSpaceAPI.Application.Queries;
using FutureSpaceAPI.Application.Responses;
using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Services;
using FutureSpaceAPI.Middlewares;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FutureSpaceAPI.Controllers
{
    /// <summary>
    /// Controller for managing launchers.
    /// </summary>
    [ApiController]
    [ApiKeyAuth]
    [Route("[controller]")]
    public class LauncherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LauncherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get the status of the API.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("REST Back-end Challenge 20201209 Running");
        }

        /// <summary>
        /// Get a launcher by its unique identifier.
        /// </summary>
        /// <param name="launcherId">The unique identifier of the launcher.</param>
        [HttpGet("{launcherId}")]
        public async Task<IActionResult> GetLauncher(Guid launcherId)
        {
            var query = new GetLauncherQuery(launcherId);
            LauncherResponse response = await _mediator.Send(query);

            if (response is null)
            {
                NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Update a launcher with new information.
        /// </summary>
        /// <param name="launchId">The unique identifier of the launcher to be updated.</param>
        /// <param name="updatedLaunch">The updated launch information.</param>
        [HttpPut("{launchId}")]
        public async Task<IActionResult> UpdateLauncher(Guid launchId, [FromBody] Launch updatedLaunch)
        {
            var command = new UpdateLauncherCommand(launchId, updatedLaunch);
            var response = await _mediator.Send(command);

            if (response is null)
            {
                NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Delete a launcher by its unique identifier.
        /// </summary>
        /// <param name="launchId">The unique identifier of the launcher to be deleted.</param>
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

        /// <summary>
        /// Get a list of launchers with pagination support.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        [HttpGet]
        [Route("launchers")]
        public async Task<IActionResult> GetLaunchers([FromQuery] int page, [FromQuery] int pageSize)
        {
            var query = new GetAllLaunchersQuery(page, pageSize);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        /// <summary>
        /// Schedule a recurring job for executing launcher services.
        /// </summary>
        [HttpGet]
        [Route("RecurringJob")]
        public void RecurringJobs()
        {
            RecurringJob.AddOrUpdate<ILauncherService>(x => x.Execute(), Cron.Daily);
            return;
        }
    }
}