﻿using PA.Data.Enums;

namespace PA.Interfaces.Models.Publication;

public class PublicationModel
{
    public string UDC { get; set; }

    public long Id { get; set; }

    public string Name { get; set; }

    public string Tags { get; set; }

    public EnumPublicationType Type { get; set; }

    public EnumPublicationStatus Status { get; set; }

    public long? ReviewerId { get; set; }

    public long UserId { get; set; }
}