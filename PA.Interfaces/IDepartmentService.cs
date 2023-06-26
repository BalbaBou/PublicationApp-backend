using PA.Interfaces.Models.Department;

namespace PA.Interfaces;

public interface IDepartmentService
{
    Task<long> AddDepartmentAsync(long facultyId, string name);

    Task<GetDepartmentsResponse> GetDepartments(GetDepartmentsRequest request);
    Task<GetDepartmentsResponse> GetDepartment(GetDepartmentRequest request);

    Task RenameDepartment(long departmentId, string name);

    Task DeleteDepartment(long departmentId);
}