namespace Api.Models.Requests;

public class ListRequestModel
{
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTimeOffset Date { get; set; }
}