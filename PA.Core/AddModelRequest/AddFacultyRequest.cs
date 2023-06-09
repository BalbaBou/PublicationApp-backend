﻿namespace PublicationApp.AddModelRequest;

/// <summary>
///     Запрос добавления факультета
/// </summary>
public class AddFacultyRequest
{
    /// <summary>
    ///     Имя факультета
    /// </summary>
    public string Name { get; set; } = string.Empty;
}