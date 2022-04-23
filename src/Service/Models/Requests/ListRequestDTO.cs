namespace Service.Models.Requests;

public class ListRequestDTO
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTimeOffset Date { get; set; }
}
