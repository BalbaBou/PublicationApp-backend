using PA.Data.Enums;
using PA.Interfaces.Models.Publication;

namespace PA.Interfaces;

public interface IPublicationService
{
    Task<long> AddPublicationAsync(AddPublicationModel model);

    Task<GetPublicationResponse> GetPublicationAsync(GetPublicationRequest request);

    Task UpdatePublicationAsync(UpdatePublicationModel model);

    Task SetPublicationStatusAsync(long publicationId, EnumPublicationStatus status);
}