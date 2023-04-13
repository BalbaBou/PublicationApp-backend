using PA.Interfaces.Models.File;

namespace PA.Interfaces.Models.Review;

public class Reviewer
{
    public long Id { get; set; }

    public string Comment { get; set; }

    public IReadOnlyCollection<PublicationFileModel> Files { get; set; }
}