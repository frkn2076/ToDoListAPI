namespace Service.Models.Requests;

public class TaskFilterRequestDTO
{
    public DateTimeOffset DeadlineMin { get; set; }

    public DateTimeOffset DeadlineMax { get; set; }

    public bool IsDone { get; set; }

    public int ListId { get; set; }
}
