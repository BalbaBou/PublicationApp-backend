using PA.Data.Enums;
using PA.Interfaces.Pagination;

namespace PA.Interfaces.Models.Publication;

public class GetPublicationRequest
{
    public string Search { get; set; }

    public long? PublicationId { get; set; }

    public EnumPublicationStatus? Status { get; set; }

    public EnumPublicationType? Type { get; set; }

    public long? UserId { get; set; }

    public long? ReviewerId { get; set; }

    public bool ExcludeDraft { get; set; } = false;

    public Page Page { get; set; } = new Page();
}