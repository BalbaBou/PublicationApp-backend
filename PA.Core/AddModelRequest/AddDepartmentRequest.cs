﻿namespace PublicationApp.AddModelRequest;

/// <summary>
///     Модель запроса добавления кафедры
/// </summary>
public class AddDepartmentRequest
{
    /// <summary>
    ///     Название кафедры
    /// </summary>
    public string DepartmentName { get; set; } = string.Empty;

    /// <summary>
    ///     Идентификатор факультета
    /// </summary>
    public long FacultyId { get; set; }
}