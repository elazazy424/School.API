using Microsoft.AspNetCore.Mvc;
using School.API.Base;
using School.Core.Features.Departments.Queries.Models;
using School.Data.AppMetaData;

namespace School.API.Controllers
{
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIdQuery query)
        {
            return NewResult(await Mediator.Send(query));
        }
    }
}
