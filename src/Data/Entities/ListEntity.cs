namespace Data.Entities;

public class ListEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTimeOffset Date { get; set; }

    public int ProfileId { get; set; }
}
