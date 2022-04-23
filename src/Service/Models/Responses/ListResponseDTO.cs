namespace Service.Models.Responses;

public class ListResponseDTO
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTimeOffset Date { get; set; }
}
