using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Faculty;

public class GetFacultyResponse : IPaginationResponse<FacultyShortModel>
{
    /// <summary>
    ///     Параметры постранички
    /// </summary>
    public Page Page { get; set; } = new Page();

    /// <summary>
    ///     Количество
    /// </summary>
    public long Count { get; set; }

    /// <summary>
    ///     Факультеты
    /// </summary>
    public IReadOnlyCollection<FacultyShortModel> Items { get; set; }
}