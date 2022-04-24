namespace Api.Models.Requests;

public class ListPaginationFilterRequestModel
{
    public DateTimeOffset DateMin { get; set; }

    public DateTimeOffset DateMax { get; set; }

    public string Title { get; set; }

    public bool IsRefresh { get; set; }
}