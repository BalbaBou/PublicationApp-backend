﻿using PA.Data.Enums;

namespace PA.Data.Models;

public class Author
{
    public long Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string SureName { get; set; } = string.Empty;

    public string Contacts { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool IsTeacher { get; set; }

    public Department? Department { get; set; }

    public long? DepartmentId { get; set; }

    public EnumEmployerPosition? EmployerPosition { get; set; }

    public EnumAcademicDegree? AcademicDegree { get; set; }

    public string? NonStuffPosition { get; set; }

    public string? NonStuffWorkPlace { get; set; }

    public List<PublicationAuthor>? Publications { get; set; }
}