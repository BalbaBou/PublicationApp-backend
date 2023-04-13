using System.ComponentModel.DataAnnotations;

namespace PA.Interfaces.Models.Reviewer;

public class AddReviewerRequest
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string SureName { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;
}