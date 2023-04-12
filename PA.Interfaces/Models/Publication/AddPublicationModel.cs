using PA.Data.Enums;

namespace PA.Interfaces.Models.Publication;

public class AddPublicationModel
{
    public string UDC { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Tags { get; set; } = string.Empty;

    public EnumPublicationType Type { get; set; }

    public long UserId { get; set; }
}