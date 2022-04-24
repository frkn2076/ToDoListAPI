namespace Service.Models.Requests;

public class ListPaginationFilterRequestDTO
{
    public DateTimeOffset DateMin { get; set; }

    public DateTimeOffset DateMax { get; set; }

    public string Title { get; set; }

    public int Count { get; set; }

    public int Skip { get; set; }

    public int ProfileId { get; set; }
}
