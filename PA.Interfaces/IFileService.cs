using PA.Interfaces.Models.File;

namespace PA.Interfaces;

public interface IFileService
{
    Task<string> AddFileAsync(AddFileModel? model);

    Task<IReadOnlyCollection<PublicationFileModel>> GetPublicationFilesAsync(long publicationId, bool isReviewer);
}