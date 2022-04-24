namespace Service.Models.Responses;

public class TaskResponseDTO
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTimeOffset Deadline { get; set; }

    public bool IsDone { get; set; }

    public int ListId { get; set; }
}
