using Microsoft.AspNetCore.Mvc;
using School.API.Base;
using School.Core.Features.ApplicationUser.Commands.Models;
using School.Data.AppMetaData;

namespace School.API.Controllers
{
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Router.ApplicationUserRouting.AddUser)]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpGet(Router.ApplicationUserRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromBody] AddUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet(Router.ApplicationUserRouting.GetById)]
        public async Task<IActionResult> GetById([FromBody] AddUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet(Router.ApplicationUserRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
