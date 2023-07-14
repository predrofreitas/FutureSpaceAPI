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

        //[HttpGet("{launchId}")]
        //public IActionResult GetLauncher(int launchId)
        //{
        //    Launcher launcher = _launchers.Find(l => l.Id == launchId);
        //    if (launcher == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(launcher);
        //}

        //[HttpGet]
        //public IActionResult GetLaunchers(int page = 1, int pageSize = 10)
        //{
        //    int totalLaunchers = _launchers.Count;
        //    int totalPages = (int)Math.Ceiling((double)totalLaunchers / pageSize);

        //    if (page < 1 || page > totalPages)
        //    {
        //        return BadRequest("Invalid page number");
        //    }

        //    List<Launcher> pagedLaunchers = _launchers
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToList();

        //    return Ok(new
        //    {
        //        TotalLaunchers = totalLaunchers,
        //        TotalPages = totalPages,
        //        Page = page,
        //        PageSize = pageSize,
        //        Launchers = pagedLaunchers
        //    });
        //}
    }
}
