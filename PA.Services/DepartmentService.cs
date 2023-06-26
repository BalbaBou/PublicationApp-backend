using Microsoft.EntityFrameworkCore;
using PA.Data;
using PA.Data.Models;
using PA.Interfaces;
using PA.Interfaces.Enums;
using PA.Interfaces.Exceptions;
using PA.Interfaces.Models.Department;
using PA.Interfaces.Pagination;

namespace PA.Services;

public class DepartmentService : IDepartmentService
{
    private readonly DataContext _db;

    public DepartmentService(DataContext db)
    {
        _db = db;
    }
    
    public async Task<long> AddDepartmentAsync(long facultyId, string name)
    {
        if (await _db.Faculties.AllAsync(x => x.Id != facultyId))
            throw new PublicationAppException($"Faculty {facultyId} is not exists!", EnumErrorCode.EntityIsNotFound);

        var department = new Department
        {
            Name = name,
            FacultyId = facultyId
        };

        await _db.Departments.AddAsync(department);
        await _db.SaveChangesAsync();

        return department.Id;
    }

    public async Task<GetDepartmentsResponse> GetDepartments(GetDepartmentsRequest request)
    {
        var query = request.FacultyId.HasValue
            ? _db.Departments.Where(x => x.FacultyId == request.FacultyId)
            : _db.Departments.AsQueryable();

        var result = await query.GetPageAsync<GetDepartmentsResponse, Department, DepartmentShortModel>(request, x =>
            new DepartmentShortModel
            {
                Id = x.Id,
                FacultyId = x.FacultyId,
                DepartmentName = x.Name
            });

        return result;
    }

    public async Task<GetDepartmentsResponse> GetDepartment(GetDepartmentRequest request)
    {
        var query = request.DepartmanetId.HasValue
            ? _db.Departments.Where(x => x.Id == request.DepartmanetId)
            : _db.Departments.AsQueryable();

        var result = await query.GetPageAsync<GetDepartmentsResponse, Department, DepartmentShortModel>(request, x =>
            new DepartmentShortModel
            {
                Id = x.Id,
                FacultyId = x.FacultyId,
                DepartmentName = x.Name
            });

        return result;
    }

    public async Task RenameDepartment(long departmentId, string name)
    {
        var department = await _db.Departments.FirstOrDefaultAsync(x => x.Id == departmentId);
        if (department is null)
            throw new PublicationAppException($"Department {departmentId} is not exists!", EnumErrorCode.EntityIsNotFound);

        department.Name = name;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteDepartment(long departmentId)
    {
        _db.Departments.Remove(new Department {Id = departmentId});
        await _db.SaveChangesAsync();
    }
}