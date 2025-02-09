namespace School.Core.Features.Students.Queries.ResultsDto
{
    public class GetStudentPaginatedListResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? DepartmentName { get; set; }
        public GetStudentPaginatedListResponse(int id, string? name, string? address, string? departmentName)
        {
            Id = id;
            Name = name;
            Address = address;
            DepartmentName = departmentName;
        }
    }
}
