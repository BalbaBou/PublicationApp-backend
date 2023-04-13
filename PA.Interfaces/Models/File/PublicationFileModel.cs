using PA.Data.Enums;

namespace PA.Interfaces.Models.File;

public class PublicationFileModel
{
    public string Name { get; set; }

    public EnumFileType Type { get; set; }

    public string Url { get; set; }

    public long? ReviewId { get; set; }
}