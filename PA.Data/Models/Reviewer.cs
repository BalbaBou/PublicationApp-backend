﻿namespace PA.Data.Models;

public class Reviewer
{
    public long Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string SureName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public List<Publication> Publications { get; set; } = null!;
}