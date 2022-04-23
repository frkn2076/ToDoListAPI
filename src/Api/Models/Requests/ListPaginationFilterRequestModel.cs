namespace Api.Models.Requests;

public class ListPaginationFilterRequestModel
{
    public DateOnly Date { get; set; }

    public string Title { get; set; }

    public bool IsRefresh { get; set; }
}