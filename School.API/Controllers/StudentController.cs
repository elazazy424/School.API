using Microsoft.AspNetCore.Mvc;
using School.API.Base;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Models;
using School.Data.AppMetaData;
using Shool.Core.Features.Students.Queries.Models;

namespace School.API.Controllers
{
    [ApiController]
    public class StudentController : AppControllerBase
    {
        #region all students list
        [HttpGet(Router.studentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var responce = await Mediator.Send(new GetStudentListQuery());
            return Ok(responce);
        }
        #endregion
        #region GetStudentPginatedListQuery
        [HttpGet(Router.studentRouting.Paginated)]
        public async Task<IActionResult> GetStudentListPaginated([FromQuery] GetStudentPginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        #endregion
        #region get student by id
        [HttpGet(Router.studentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetStudentByIdQuery(id)));
        }
        #endregion
        #region add student
        [HttpPost(Router.studentRouting.Create)]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand command)
        {
            var responce = await Mediator.Send(command);
            return NewResult(responce);
        }
        #endregion
        #region edit student
        [HttpPut(Router.studentRouting.Edit)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand command)
        {
            var responce = await Mediator.Send(command);
            return NewResult(responce);
        }
        #endregion
        #region delete student
        [HttpDelete(Router.studentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteStudentCommand(id)));
        }
        #endregion
    }
}
