using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using PA.Data;
using PA.Services;

namespace PA.Test;

public class FacultyServiceTests
{
    [Test]
    public async Task Test1()
    {
        var service = new FacultyService(new DataContext());
        var faculty = await service.CreateFacultyAsync("ФМФ");
        Assert.True(faculty==await service.GetFacultyAsync(faculty.Id));
    }
}