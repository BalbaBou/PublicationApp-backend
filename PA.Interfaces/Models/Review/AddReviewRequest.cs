namespace PA.Interfaces.Models.Review;

public class AddReviewRequest
{
    public long PublicationId { get; set; }

    public string Comment { get; set; } = string.Empty;
}