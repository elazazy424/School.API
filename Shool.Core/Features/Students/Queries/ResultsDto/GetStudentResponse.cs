﻿namespace School.Core.Features.Students.Queries.ResultsDto
{
    public class GetStudentResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? DepartmentName { get; set; }
    }
}
