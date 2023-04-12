using PA.Interfaces.Enums;

namespace PA.Interfaces.Exceptions;

public class PublicationAppException : Exception
{
    public PublicationAppException(string? message = null, EnumErrorCode errorCode = EnumErrorCode.Unknown) : base(message ?? errorCode.GetDescription())
    {
        ErrorCode = errorCode;
    }

    public PublicationAppException(EnumErrorCode errorCode) : base(errorCode.GetDescription())
    {
        ErrorCode = errorCode;
    }

    public EnumErrorCode ErrorCode { get; set; }
}