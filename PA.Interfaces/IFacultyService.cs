using PA.Data.Models;
using PA.Interfaces.Models.Faculty;

namespace PA.Interfaces;

public interface IFacultyService
{
    Task<Faculty?> CreateFacultyAsync(string name);
    Task<GetFacultyResponse> GetAllFacultyAsync(GetFacultyRequest request);
    Task<Faculty?> GetFacultyAsync(long facultyId);
    Task RenameFacultyAsync(long facultyId, string name);
    Task DeleteFacultyAsync(long facultyId);
}